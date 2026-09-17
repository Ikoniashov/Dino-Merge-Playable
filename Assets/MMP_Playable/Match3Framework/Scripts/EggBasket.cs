using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class EggBasket : MonoBehaviour
{
    #region Fields

    [SerializeField] private DragObject m_thisDragObject;

    [SerializeField] private string m_eggGenericId = "egg";
    [SerializeField] private int m_eggCountToSpawn = 3;
    [SerializeField] private Vector2Int[] m_spawnPositions;

    private List<DragObject> m_eggs = new List<DragObject>();

    #endregion

    #region UnityEvents

    private void Start()
    {
        InitializeTutorial();
    }

    #endregion

    #region Public

    public void ActivateBasket()
    {
        AudioSystem.Instance.PlayOpenEggBasketSound();
        TutorialHand.Instance.NotifyBasketOpened();

        foreach (var pos in m_spawnPositions)
        {
            SpawnEggAt(pos.x, pos.y);
        }

        DestroyBasket();

        m_thisDragObject.objectManager.tapTextTutorial.FadeGroup(0f, 1f);
    }

    public string Resolve(string a_genericId)
    {
        // Если ObjectSet ещё не выбран или не назначен
        if (DinoSelectionManager.Instance.CurrentObjectSet == null)
            return a_genericId;

        var set = DinoSelectionManager.Instance.CurrentObjectSet;

        var mapping = set.Mappings
            .FirstOrDefault(m => m.GenericId == a_genericId);

        // Если маппинга нет — вернём genericId (на случай ошибок)
        return mapping != null ? mapping.ConcreteType : a_genericId;
    }

    #endregion

    #region Private

    private async void InitializeTutorial()
    {
        await Task.Delay(3000);

        m_thisDragObject.objectManager.tapTextTutorial.FadeGroup(1f, 0.5f);
    }

    private void DestroyBasket()
    {
        m_thisDragObject.transform.DOScale(0f, 0.5f).SetEase(Ease.InBack).OnComplete(() =>
        {
            m_thisDragObject.currentCell.Vacate();
            transform.gameObject.SetActive(false);
            ObjectManager.Instance.spawnedObjects.Remove(m_thisDragObject);
        });
    }

    private void SpawnEggAt(int a_x, int a_y)
    {
        GridCell cell = MainSystem.Instance.GetCell(a_x, a_y);
        if (cell == null || cell.IsOccupied) return;

        string concreteEggType = Resolve(m_eggGenericId);

        DragObject egg = m_thisDragObject.objectManager.SpawnStartedObject(concreteEggType, cell);

        if (egg != null)
        {
            egg.Initialize(cell, m_thisDragObject.objectManager, true);
            egg.transform.position = transform.position;
            m_eggs.Add(egg);

            AnimateMovingToCell(egg);
        }
    }

    private void AnimateMovingToCell(DragObject a_dragObject)
    {
        Transform tr = a_dragObject.transform;
        Vector3 start = tr.position;
        Vector3 end = a_dragObject.currentCell.transform.position;

        float duration = 0.6f;
        float arcHeight = 1.5f;        // высота основной дуги
        float bounceHeight = 0.1f;     // высота маленького отскока после посадки
        float bounceDuration = 0.18f;  // длительность подпрыжка

        tr.DOKill();

        // Основная баллистика
        DOVirtual
            .Float(0f, 1f, duration, t =>
            {
                Vector3 pos = Vector3.Lerp(start, end, t);
                pos.y += arcHeight * 4f * t * (1f - t); // парабола
                tr.position = pos;
            })
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                tr.position = end; // фиксируем позицию

                // Отскок: вверх → вниз
                Sequence bounce = DOTween.Sequence();

                bounce.Append(
                    tr.DOMoveY(end.y + bounceHeight, bounceDuration * 0.5f)
                      .SetEase(Ease.OutQuad)
                );

                bounce.Append(
                    tr.DOMoveY(end.y, bounceDuration * 0.5f)
                      .SetEase(Ease.InQuad)
                );
            });
    }

    #endregion
}