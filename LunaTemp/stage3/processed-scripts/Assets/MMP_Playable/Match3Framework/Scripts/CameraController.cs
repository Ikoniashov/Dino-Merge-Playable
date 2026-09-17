using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Fields

    [SerializeField] private BoxCollider m_movingBounds;
    [SerializeField] private Transform m_initPoint;

    [Header("Zoom props")]
    [SerializeField] private float m_zoomMin = 7f;
    [SerializeField] private float m_zoomMax = 19f;
    [SerializeField] private float m_zoomSens = 4f;
    [SerializeField] private float m_zoomSmooth = 6f;
    [SerializeField] private float m_defaultZoom = 19f;

    [Header("Moving Props")]
    [SerializeField] private float m_movingSens = 0.03f;
    [SerializeField] private float m_movingSmoothness = 15f;

    [SerializeField] private float m_tapThreshold = 15f;

    [Header("Inertia props")]
    [SerializeField] private float m_inertiaSmoothness = 1f;
    [SerializeField] private float m_initialInertiaModifier = 0f;

    [SerializeField] private bool m_canDrag = true;
    [SerializeField] private bool m_stopInertia;

    [SerializeField] private Camera m_mainCamera;
    [SerializeField] private float m_zoomSpeed = 10f;
    [SerializeField] private Vector2 m_zoomDifferenceLimits;

    private bool m_isPinching;
    private Transform m_mTransform;

    private float m_initOrthoSize;
    private float m_currOrthoSize;
    private float m_zoomDifference;

    private Vector2 m_touchStart;
    private Vector3 m_prevTouch;
    private Vector3 m_needCamPos;
    private Vector3 m_startCamPos;

    private List<Vector2> m_prevTouches;

    #endregion

    #region UnityEvents

    private void Awake()
    {
        m_mTransform = GetComponent<Transform>();
        m_prevTouches = new List<Vector2>();
        m_canDrag = true;

        transform.position = m_initPoint.position;

        ChangeCamerasZoom(0, true);

        m_initOrthoSize = m_defaultZoom;
        m_currOrthoSize = m_initOrthoSize;
        m_mainCamera.orthographicSize = m_initOrthoSize;
    }

    private void Update()
    {
        HandleInput();
        HandleZoom();
    }

    #endregion

    #region Public

    public void MoveToPosition([Bridge.Ref] Vector3 a_worldPosition, float a_delay)
    {
        m_canDrag = false;
        m_needCamPos = GetLimitedCameraPosition(a_worldPosition);
        var seq = DOTween.Sequence();
        seq.SetDelay(a_delay);
        seq.Append(m_mTransform.DOMove(m_needCamPos, 1f).SetEase(Ease.OutCubic).OnComplete(() => m_canDrag = true));
        seq.Play();
    }

    public void CheckRaycastHit([Bridge.Ref] RaycastHit a_hit)
    {
        Debug.Log(a_hit);
    }

    public void ChangeCamerasZoom(float a_newValue, bool a_immediately = false)
    {
        if (a_newValue == 0f)
            a_newValue = m_defaultZoom;

        if (Mathf.Abs(a_newValue - m_mainCamera.orthographicSize) < 1f)
            return;

        var dur = a_immediately ? 0 : Mathf.Abs(m_mainCamera.orthographicSize - a_newValue);

        m_mainCamera.DOOrthoSize(a_newValue, dur).SetEase(Ease.InOutQuad);
    }


    #endregion

    #region Private

    private void HandleInput()
    {
        if (!Application.isFocused)
            return;

        if ((DragManager.Instance != null && DragManager.Instance.IsDragging)
            || FlyingDragManager.Instance != null && FlyingDragManager.Instance.IsDragging)
            return;

        if (Application.isMobilePlatform)
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                m_touchStart = Input.touches[0].position;
                m_prevTouch = Input.touches[0].position;

                m_startCamPos = m_mTransform.position;
                m_needCamPos = m_mTransform.position;

                m_prevTouches.Clear();
            }
            else if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved && m_canDrag && !m_isPinching)
            {
                var dir = m_touchStart - Input.touches[0].position;

                m_prevTouches.Add(Input.GetTouch(0).deltaPosition);

                if (m_prevTouches.Count > 5)
                    m_prevTouches.RemoveAt(0);

                var currSens = m_movingSens;
                currSens *= m_mainCamera.orthographicSize / m_defaultZoom;

                m_needCamPos = m_startCamPos + Vector3.up * dir.y * currSens;
                m_needCamPos = GetLimitedCameraPosition(m_needCamPos);
                m_needCamPos += Vector3.right * dir.x * currSens;
                m_needCamPos = GetLimitedCameraPosition(m_needCamPos);

                m_mTransform.position = Vector3.Lerp(m_mTransform.position, m_needCamPos, m_movingSmoothness * Time.deltaTime);
            }
            else if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (Vector3.Distance(m_touchStart, Input.GetTouch(0).position) < m_tapThreshold)
                {
                    var ray = Camera.main.ScreenPointToRay((Vector2)Input.mousePosition);
                    if (Physics.Raycast(ray, out var hit, 50))
                    {
                        //Обработка тапа
                        CheckRaycastHit(hit);
                    }
                }
                else
                {
                    StartCoroutine(CamInertia());
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_touchStart = Input.mousePosition;

                m_needCamPos = m_mTransform.position;
                m_prevTouch = Input.mousePosition;
                m_prevTouches.Clear();
            }
            else if (Input.GetMouseButton(0) && m_canDrag)
            {
                var dir = m_prevTouch - Input.mousePosition;
                m_prevTouch = Input.mousePosition;

                var currSens = m_movingSens;
                currSens *= m_mainCamera.orthographicSize / m_defaultZoom;

                m_needCamPos += Vector3.up * dir.y * currSens;
                m_needCamPos = GetLimitedCameraPosition(m_needCamPos);
                m_needCamPos += Vector3.right * dir.x * currSens;
                m_needCamPos = GetLimitedCameraPosition(m_needCamPos);

                m_mTransform.position =
                    Vector3.Lerp(m_mTransform.position, m_needCamPos, m_movingSmoothness * Time.deltaTime);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (Vector3.Distance(m_touchStart, m_prevTouch) < m_tapThreshold)
                {
                    var ray = Camera.main.ScreenPointToRay((Vector2)Input.mousePosition);

                    if (Physics.Raycast(ray, out var hit, 50))
                    {
                        //Обработка тапа
                        CheckRaycastHit(hit);
                    }
                }
            }
        }
    }

    private void HandleZoom()
    {
        if (!Application.isFocused) return;

        // Зум колесиком...
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0) { /* ... */ }

        // ПИНЧ-ЗУМ
        if (Input.touchCount == 2 && m_canDrag)
        {
            m_isPinching = true;  // ← ВКЛЮЧАЕМ блокировку при 2 пальцах

            var touchZero = Input.GetTouch(0);
            var touchOne = Input.GetTouch(1);

            if (touchOne.phase == TouchPhase.Began || Mathf.Abs(m_zoomDifference) > 100f)
            {
                m_initOrthoSize = m_mainCamera.orthographicSize;
                m_currOrthoSize = m_initOrthoSize;
                m_zoomDifference = 0;
                m_zoomDifferenceLimits.x = m_zoomMin - m_initOrthoSize;
                m_zoomDifferenceLimits.y = m_zoomMax - m_initOrthoSize;
            }

            // ... расчёт зума
            var prevTouchZeroPos = touchZero.position - touchZero.deltaPosition;
            var prevTouchOnePos = touchOne.position - touchOne.deltaPosition;
            var prevMagnitude = (prevTouchZeroPos - prevTouchOnePos).magnitude;
            var currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float magnitudeDiff = currentMagnitude - prevMagnitude;
            m_zoomDifference -= magnitudeDiff * m_zoomSens;
            m_zoomDifference = Mathf.Clamp(m_zoomDifference, m_zoomDifferenceLimits.x, m_zoomDifferenceLimits.y);

            float targetSize = m_initOrthoSize + m_zoomDifference;
            m_currOrthoSize = Mathf.Lerp(m_currOrthoSize, Mathf.Clamp(targetSize, m_zoomMin, m_zoomMax), m_zoomSmooth * Time.deltaTime);
            m_mainCamera.orthographicSize = m_currOrthoSize;
        }
        // СБРОС ПРИ ОКОНЧАНИИ ПИНЧА (touchCount < 2)
        else if (Input.touchCount < 2)
        {
            if (m_zoomDifference != 0)
            {
                // Плавно "дожимаем" зум
                m_currOrthoSize = Mathf.Lerp(m_currOrthoSize, m_mainCamera.orthographicSize, m_zoomSmooth * Time.deltaTime);
                m_mainCamera.orthographicSize = m_currOrthoSize;
                if (Mathf.Abs(m_zoomDifference) < 0.01f)
                    m_zoomDifference = 0;
            }

            // ← КРИТИЧНО: выключаем блокировку, НО с задержкой
            if (Input.touchCount == 0)  // Только когда ВСЕ пальцы убраны
            {
                m_isPinching = false;
                m_zoomDifference = 0;
            }
        }
    }

    private IEnumerator CamInertia()
    {
        yield return new WaitUntil(() => Input.touchCount == 0);

        if (m_prevTouches.Count == 0)
            yield break;

        m_stopInertia = false;
        var startInertia = new Vector2(m_prevTouches.Average(vec => vec.x), m_prevTouches.Average(vec => vec.y));

        var currInertia = startInertia * m_initialInertiaModifier;

        while (currInertia.magnitude > 1f && Input.touchCount == 0 && !m_stopInertia)
        {
            m_needCamPos -= Vector3.up * currInertia.y * m_movingSens;
            m_needCamPos = GetLimitedCameraPosition(m_needCamPos);
            m_needCamPos -= Vector3.right * currInertia.x * m_movingSens;
            m_needCamPos = GetLimitedCameraPosition(m_needCamPos);

            m_mTransform.position =
                Vector3.Lerp(m_mTransform.position, m_needCamPos, m_movingSmoothness * Time.deltaTime);

            currInertia = Vector2.Lerp(currInertia, Vector2.zero, m_inertiaSmoothness * Time.deltaTime);
            yield return null;
        }

        m_stopInertia = false;
    }

    private Vector3 GetLimitedCameraPosition(Vector3 a_inPos)
    {
        Vector3 limitedPos = m_movingBounds.ClosestPoint(a_inPos);

        // Сохраняем текущий Z камеры (не даём измениться)
        limitedPos.z = m_mTransform.position.z;

        return limitedPos;
    }

    #endregion
}