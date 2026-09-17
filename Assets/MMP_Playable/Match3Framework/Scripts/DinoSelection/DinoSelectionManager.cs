using DG.Tweening;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DinoSelectionManager : MonoBehaviour
{
    #region Fields

    public static DinoSelectionManager Instance { get; private set; }

    [SerializeField] private MainSystem m_mainSystem;
    [SerializeField] private CameraController m_cameraController;

    [SerializeField] private GameObject m_choosingScreenOverlay;

    [SerializeField] private DinoCarousel m_dinoCarousel;

    [SerializeField] private ParticleSystem m_heartEffect;

    [SerializeField] private Transform m_chosenDinoPosition;

    [SerializeField] private Transform m_logoPlayNowButton;
    [SerializeField] private Transform m_logoPlayNowNewButtonPosition;

    [SerializeField] private Button m_nextDinoButton;

    [SerializeField] private Button m_previousDinoButton;

    [SerializeField] private Button m_chooseDinoButton;

    [SerializeField] private TutorialHandPointer m_tutorialHandChooseButton;

    [SerializeField] private TutorialHandPointer m_arrowHandTutorial;

    [SerializeField] private GameObject m_choosingScreenWorldCanvas;

    [SerializeField] private MapObjectLayoutManager m_mapObjectLayoutManager;

    [SerializeField] private List<ObjectSet> m_dinoObjectSets;

    [SerializeField] private GameObject m_rewardCard;

    [SerializeField] private Image m_rewardCardImage;

    [SerializeField] private GameObject m_carouselGroup;

    private ObjectSet m_currentObjectSet;

    #endregion

    #region Properties

    public ObjectSet CurrentObjectSet
    {
        get { return m_currentObjectSet; }
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

    private void OnEnable()
    {
        m_nextDinoButton.onClick.AddListener(ShowNextDino);
        m_previousDinoButton.onClick.AddListener(ShowPreviousDino);
        m_chooseDinoButton.onClick.AddListener(ChooseDino);
    }

    private void OnDisable()
    {
        m_nextDinoButton.onClick.RemoveAllListeners();
        m_previousDinoButton.onClick.RemoveAllListeners();
        m_chooseDinoButton.onClick.RemoveAllListeners();
    }

    #endregion

    #region Public

    public void ApplyObjectSetToMap(MapObjectLayoutManager a_map, ObjectSet a_set)
    {
        List<MapObjectLayoutManager.CellObjectData> allCells = a_map.GetObjectCells();

        foreach (MapObjectLayoutManager.CellObjectData c in allCells)
        {
            ObjectMapping mapping = a_set.Mappings.Find(m => m.GenericId == c.objectType);

            if (mapping != null)
                c.objectType = mapping.ConcreteType;
        }
    }

    public async void ShowRewardCardFinal()
    {
        m_heartEffect.Play();

        await Task.Delay(500);

        m_cameraController.enabled = false;

        m_choosingScreenOverlay.SetActive(true);
        m_choosingScreenWorldCanvas.SetActive(true);

        m_choosingScreenOverlay.FadeGroup(1f, 1f);
        m_choosingScreenWorldCanvas.FadeGroup(1f, 1f);

        await Task.Delay(1000);

        m_rewardCard.FadeGroup(1f, 1f);

        await Task.Delay(1000);

        //Luna.Unity.Playable.InstallFullGame();
        //Luna.Unity.LifeCycle.GameEnded();
    }

    #endregion

    #region Private

    private void ApplyChosenSet(ObjectSet a_selectedSet)
    {
        ApplyObjectSetToMap(m_mapObjectLayoutManager, a_selectedSet);
    }

    private async void ChooseDino()
    {
        m_chooseDinoButton.onClick.RemoveAllListeners();
        m_tutorialHandChooseButton.StopTutorialHandAnimation();

        int dinoIndex = m_dinoCarousel.GetCurrentIndex();
        m_currentObjectSet = m_dinoObjectSets[dinoIndex];

        AudioSystem.Instance.PlayClickSound();

        ApplyChosenSet(m_currentObjectSet);

        m_chooseDinoButton.gameObject.FadeGroup(0f, 0.5f);

        m_dinoCarousel.HideSelectionChrome();

        m_dinoCarousel.transform.DOMove(m_chosenDinoPosition.position, 0.8f);

        AudioSystem.Instance.PlayChooseSound();

        m_mainSystem.CreateGridObjects();

        await Task.Delay(1000);

        HideChoosingScreen();
    }

    private async void HideChoosingScreen()
    {
        m_heartEffect.Play();

        m_rewardCardImage.sprite = m_currentObjectSet.RewardCardSprite;

        await Task.Delay(1000);

        m_logoPlayNowButton.transform.DOMove(m_logoPlayNowNewButtonPosition.position, 1f);

        m_choosingScreenOverlay.FadeGroup(0f, 1f);
        m_choosingScreenWorldCanvas.FadeGroup(0f, 1f);

        await Task.Delay(1000);

        m_cameraController.enabled = true;

        m_choosingScreenOverlay.SetActive(false);
        m_choosingScreenWorldCanvas.SetActive(false);

        m_carouselGroup.SetActive(false);

        m_chooseDinoButton.gameObject.SetActive(false);
    }

    private void ShowNextDino()
    {
        m_dinoCarousel.ChangeToRight();
        m_arrowHandTutorial.StopTutorialHandAnimation();
        m_tutorialHandChooseButton.gameObject.SetActive(true);
    }

    private void ShowPreviousDino()
    {
        m_dinoCarousel.ChangeToLeft();
        m_arrowHandTutorial.StopTutorialHandAnimation();
        m_tutorialHandChooseButton.gameObject.SetActive(true);
    }

    #endregion
}
