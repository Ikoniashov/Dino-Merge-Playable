using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class TutorialHand : MonoBehaviour
{
    #region Fields
    public static TutorialHand Instance { get; private set; }

    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private ObjectManager m_objectManager;
    [SerializeField] private float m_playerInactivityForTutorial = 4f;

    private Vector3 m_startAnimationPosition;
    private Vector3 m_endAnimationPosition;

    private Color m_startedColor;
    private Color m_alphaColor;

    private Sequence m_handSequence;

    private DragObject m_startedObject;
    private DragObject m_endObject;

    private bool m_isFirstTutorialStepStarted;
    private bool m_isSecondTutorialStepStarted;
    private bool m_isThirdTutorialStepStarted;

    private float m_inactivityTime;
    private bool m_playerActive = false;

    private Coroutine m_tutorialCoroutine;
    public Coroutine tutorialCoroutine
    {
        get => m_tutorialCoroutine;
        set => m_tutorialCoroutine = value;
    }

    #endregion

    #region UnityEvents

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        foreach (var dragObject in m_objectManager.spawnedObjects)
        {
            dragObject.e_onObjectSelected -= OnObjectSelectedToMerge;
            dragObject.e_onObjectSelected -= OnObjectSelected;
            dragObject.e_onObjectMoved -= OnObjectMoved;
        }
    }

    #endregion

    #region Public 

    public void StopCoroutine()
    {
        OnPlayerAction();

        if (m_tutorialCoroutine != null)
        {
            StopCoroutine(tutorialCoroutine);
            m_tutorialCoroutine = null;
        }
    }

    public void SetStartColor()
    {
        m_startedColor = Color.white;
        m_alphaColor = new Color(m_startedColor.r, m_startedColor.g, m_startedColor.b, 0f);
    }

    public void ShowTapTutorialStep([Bridge.Ref] Vector3 a_pointPosition)
    {
        SetStartColor();
        StartTutorialPointAnimation(a_pointPosition);
    }

    public void ShowMovingTutorialStep(DragObject a_startedObject, DragObject a_mergableObject, bool a_needToMerge = false)
    {
        SetStartColor();
        StartTutoriaMovingAnimation(a_startedObject, a_mergableObject, a_needToMerge);
    }

    public void StartTutoriaMovingAnimation(DragObject a_startedObject, DragObject a_mergeableObject, bool a_needToMerge)
    {
        m_startAnimationPosition = a_startedObject.currentCell.transform.position;

        if (a_mergeableObject == null) return;

        var cell = a_mergeableObject.currentCell;

        if (a_needToMerge)
        {
            m_endAnimationPosition = cell.transform.position;
        }
        else
        {
            var neighbors = new[]
            {
                cell.RightNeighbor,
                cell.LeftNeighbor,
                cell.TopNeighbor,
                cell.BottomNeighbor
            };

            var freeNeighbor = neighbors.FirstOrDefault(n => n != null && !n.IsOccupied);

            if (freeNeighbor == null)
                return;

            m_endAnimationPosition = freeNeighbor.transform.position;
        }

        m_startedObject = a_startedObject;
        m_endObject = a_mergeableObject;

        transform.position = m_startAnimationPosition;
        transform.gameObject.SetActive(true);

        if (a_needToMerge)
            a_startedObject.e_onObjectSelected += OnObjectSelectedToMerge;
        else
            a_startedObject.e_onObjectSelected += OnObjectSelected;

        StartTutorialMoveHandAnimation();
    }

    public void StartTutorialPointAnimation([Bridge.Ref] Vector3 a_pointToShow)
    {
        m_startAnimationPosition = a_pointToShow;

        transform.position = m_startAnimationPosition;
        transform.gameObject.SetActive(true);

        foreach (var dragObject in m_objectManager.spawnedObjects)
            dragObject.e_onObjectMoved += OnObjectMoved;

        StartTutorialTapHandAnimation();
    }

    public void StopTutorialHandAnimation()
    {
        if (m_handSequence != null)
        {
            m_handSequence.Kill();
            m_handSequence = null;
        }

        m_spriteRenderer.DOFade(0f, 0.3f);
    }

    public async void ActivateTutorialAfterPlayerInactivity()
    {
        await Task.Delay(1000);

        if (m_tutorialCoroutine != null)
            return;

        List<DragObject> mergeCandidate = new List<DragObject>();

        var groupsCandidates = new Dictionary<(string objectType, int level), List<DragObject>>();

        foreach (var obj in m_objectManager.spawnedObjects)
        {
            if (!obj.canBeMerged)
                continue;

            var key = (obj.objectType, obj.level);

            if (!groupsCandidates.ContainsKey(key))
                groupsCandidates[key] = new List<DragObject>();

            groupsCandidates[key].Add(obj);
        }

        // теперь ищем первую группу, где 2 и более объектов
        foreach (var group in groupsCandidates.Values)
        {
            if (group.Count >= 2)
            {
                mergeCandidate = group;
                break;
            }
        } // выбираем первую подходящую группу

        Debug.Log("After Merge Candidate");

        if (mergeCandidate == null)
        {
            Debug.Log("MergeCandidate == null");
            return;
        }
        else
        {
            Debug.Log("MergeCandidate != null");
        }

        bool isMergeNeeded = false;

        var groups = new Dictionary<(string objectType, int level), List<DragObject>>();

        foreach (var obj in mergeCandidate)
        {
            if (!obj.canBeMerged)
                continue;

            var key = (obj.objectType, obj.level);

            if (!groups.ContainsKey(key))
                groups[key] = new List<DragObject>();

            groups[key].Add(obj);
        }

        // Проверяем каждую группу
        foreach (var group in groups.Values)
        {
            if (group.Count < group[0].mergeThreshold)
                continue;

            // Проверяем все пары объектов внутри группы
            for (int i = 0; i < group.Count; i++)
            {
                for (int j = i + 1; j < group.Count; j++)
                {
                    if (group[i].IsNeighborWith(group[j]))
                    {
                        isMergeNeeded = true;
                        break;
                    }
                }

                if (isMergeNeeded)
                    break;
            }

            if (isMergeNeeded)
                break;
        }

        Debug.Log("After bool IsNeeded");

        // если нашли подходящие объекты — берём первый для примера
        List<DragObject> isolatedCandidates = new List<DragObject>();

        foreach (var obj in mergeCandidate)
        {
            bool hasNeighbor = false;

            foreach (var other in mergeCandidate)
            {
                if (other == obj)
                    continue;

                if (obj.objectType == other.objectType &&
                    obj.level == other.level &&
                    obj.IsNeighborWith(other))
                {
                    hasNeighbor = true;
                    break;
                }
            }

            if (!hasNeighbor)
                isolatedCandidates.Add(obj);
        }

        Debug.Log("After Isolated Candidates");

        // если таких нет — fallback: берём любой
        var exampleObject = isolatedCandidates.FirstOrDefault() ?? mergeCandidate.FirstOrDefault();

        Debug.Log("After exampleObject");

        if (exampleObject != null)
        {
            Debug.Log("ExampleObject is not null");
            m_tutorialCoroutine = StartCoroutine(TutorialAfterInactivity(exampleObject, isMergeNeeded));
        }
    }

    #endregion

    #region Private

    private IEnumerator TutorialAfterInactivity(DragObject a_dragObject, bool a_needToMerge)
    {
        Debug.Log("Inside Coroutine");

        if (a_dragObject == null) yield break;

        m_inactivityTime = 0f;
        m_playerActive = false;

        while (m_inactivityTime < m_playerInactivityForTutorial)
        {
            if (m_playerActive)
                yield break; // игрок проявил активность — отменяем запуск туториала

            m_inactivityTime += Time.deltaTime;
            yield return null;
        }

        // если прошло 4 секунды и игрок не активен
        if (!m_playerActive)
            ShowMovingTutorialStep(a_dragObject, m_objectManager.spawnedObjects
                .FirstOrDefault(x => x.objectType == a_dragObject.objectType
                             && x != a_dragObject && x.canBeMerged), a_needToMerge);

        m_tutorialCoroutine = null;
    }

    // Вызывать этот метод при любом действии игрока (тап, свайп и т.п.)
    private void OnPlayerAction()
    {
        m_playerActive = true;
    }

    private void OnObjectSelected(DragObject a_dragObject)
    {
        var cell = (a_dragObject == m_endObject)
            ? m_startedObject.currentCell
            : m_endObject.currentCell;

        var neighbors = new[]
        {
            cell.RightNeighbor,
            cell.LeftNeighbor,
            cell.TopNeighbor,
            cell.BottomNeighbor
    };

        GridCell freeNeighbor = neighbors.FirstOrDefault(n => n != null && !n.IsOccupied);

        if (freeNeighbor == null)
            return;

        StartTutorialPointAnimation(freeNeighbor.transform.position);

        m_startedObject.e_onObjectSelected -= OnObjectSelected;
    }

    private void OnObjectSelectedToMerge(DragObject a_dragObject)
    {
        if (a_dragObject == m_endObject)
            StartTutorialPointAnimation(m_startedObject.transform.position);
        else
            StartTutorialPointAnimation(m_endObject.transform.position);

        m_startedObject.e_onObjectSelected -= OnObjectSelectedToMerge;
    }

    private void OnObjectMoved(DragObject a_dragObject)
    {
        foreach (var dragObject in m_objectManager.spawnedObjects)
        {
            if (a_dragObject.IsNeighborWith(dragObject) && m_endAnimationPosition == a_dragObject.currentCell.transform.position)
            {
                StopTutorialHandAnimation();
                m_startedObject.e_onObjectMoved -= OnObjectMoved;

                return;
            }
        }
    }

    private void StartTutorialTapHandAnimation()
    {
        if (m_handSequence != null)
        {
            m_handSequence.Kill();
        }

        // Сбрасываем состояние
        transform.localScale = Vector3.one;
        m_spriteRenderer.color = m_startedColor;

        m_handSequence = DOTween.Sequence();

        // Анимация "двойного тапа"
        m_handSequence.Append(m_spriteRenderer.DOFade(1f, 0.5f)) // плавное появление
                                                                 // Первый тап — уменьшение и возврат
                      .Append(transform.DOScale(0.9f, 0.15f).SetEase(Ease.InOutSine))
                      .Append(transform.DOScale(1f, 0.15f).SetEase(Ease.InOutSine))
                      // Небольшая пауза между кликами
                      .AppendInterval(0.1f)
                      // Второй тап — тоже уменьшение и возврат
                      .Append(transform.DOScale(0.9f, 0.15f).SetEase(Ease.InOutSine))
                      .Append(transform.DOScale(1f, 0.15f).SetEase(Ease.InOutSine))
                      // Задержка перед повтором
                      .AppendInterval(0.7f)
                      // Исчезание перед циклом
                      .Append(m_spriteRenderer.DOFade(0f, 0.5f))
                      .AppendInterval(0.3f)
                      .SetLoops(-1, LoopType.Restart) // бесконечный повтор
                      .Play();
    }

    private void StartTutorialMoveHandAnimation()
    {
        if (m_handSequence != null)
        {
            m_handSequence.Kill();
        }

        m_spriteRenderer.color = m_alphaColor;
        transform.position = m_startAnimationPosition;

        // Создаём последовательность
        m_handSequence = DOTween.Sequence();

        m_handSequence.Append(m_spriteRenderer.DOFade(1f, 0.5f)) // Плавное появление
                      .Append(transform.DOMove(m_endAnimationPosition, 1f).SetEase(Ease.InOutSine)) // Движение
                      .Append(m_spriteRenderer.DOFade(0f, 0.5f)) // Исчезание
                      .AppendCallback(() =>
                      {
                          transform.position = m_startAnimationPosition; // Вернуться в начало
                      })
                      .SetLoops(-1, LoopType.Restart) // Бесконечный повтор цикла
                      .Play();
    }

    #endregion
}
