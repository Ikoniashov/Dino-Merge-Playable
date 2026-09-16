using DG.Tweening;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PairManager : MonoBehaviour
{
    #region Fields

    public static PairManager Instance { get; private set; }

    [SerializeField] private MainSystem m_mainSystem;
    [SerializeField] private CameraController m_cameraController;

    [SerializeField] private GameObject choosingPrincessFirstSceneGameObject;

    [SerializeField] private PairEntity m_princeToChooseEntity;
    [SerializeField] private PairEntity m_princessToChooseEntity;

    [SerializeField] private ParticleSystem m_appearEffect;
    [SerializeField] private ParticleSystem m_heartEffect;

    [SerializeField] private Transform m_princePositionToPair;
    [SerializeField] private Transform m_princessPositionToPair;

    [SerializeField] private Transform m_logoPlayNowButton;
    [SerializeField] private Transform m_logoPlayNowNewButtonPosition;

    [SerializeField] private Image m_choosingPairBackgroundImageScene;

    [SerializeField] private Button m_changePrincessRightButton;
    [SerializeField] private Button m_changePrincessLeftButton;
    [SerializeField] private Button m_pairButton;

    [SerializeField] private TutorialHandPairButton m_tutorialHandPairButton;
    [SerializeField] private TutorialHandPairButton m_arrowHandTutorial;

    [SerializeField] private GameObject m_choosingPrincessFromSecondCanvas;

    [SerializeField] private MapObjectLayoutManager m_mapObjectLayoutManager;

    [SerializeField] private List<ObjectSet> m_princessObjectSets;

    [SerializeField] private GameObject m_happilyEverAfter;
    [SerializeField] private Image m_happilyEverAfterImage;
    [SerializeField] GameObject m_framesEntitesGroup;

    private ObjectSet m_currentObjectSet;
    public ObjectSet currentObjectSet => m_currentObjectSet;

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
        m_changePrincessRightButton.onClick.AddListener(ChangePrincessRightSide);
        m_changePrincessLeftButton.onClick.AddListener(ChangePrincessLeftSide);
        m_pairButton.onClick.AddListener(PairEntities);
    }

    private void OnDisable()
    {
        m_changePrincessRightButton.onClick.RemoveAllListeners();
        m_changePrincessLeftButton.onClick.RemoveAllListeners();
        m_pairButton.onClick.RemoveAllListeners();
    }

    #endregion

    #region Public

    public void ApplyObjectSetToMap(MapObjectLayoutManager a_map, ObjectSet a_set)
    {
        var allCells = a_map.GetObjectCells();

        foreach (var c in allCells)
        {
            ObjectMapping mapping = a_set.Mappings.Find(m => m.GenericId == c.objectType);
            if (mapping != null)
                c.objectType = mapping.ConcreteType;
        }
    }

    public async void HappilyEverAfterFinal()
    {
        m_heartEffect.Play();

        await Task.Delay(500);

        m_cameraController.enabled = false;

        choosingPrincessFirstSceneGameObject.SetActive(true);
        m_choosingPrincessFromSecondCanvas.SetActive(true);

        choosingPrincessFirstSceneGameObject.FadeGroup(1f, 1f);
        m_choosingPrincessFromSecondCanvas.FadeGroup(1f, 1f);

        await Task.Delay(1000);

        m_happilyEverAfter.FadeGroup(1f, 1f);

        await Task.Delay(1000);

        //Luna.Unity.Playable.InstallFullGame();
        //Luna.Unity.LifeCycle.GameEnded();
    }

    #endregion

    #region Private

    private void HandlePair(ObjectSet a_selectedSet)
    {
        ApplyObjectSetToMap(m_mapObjectLayoutManager, a_selectedSet);
    }

    private async void PairEntities()
    {
        m_pairButton.onClick.RemoveAllListeners();
        m_tutorialHandPairButton.StopTutorialHandAnimation();

        int princessIndex = m_princessToChooseEntity.GetCurrentIndex();
        m_currentObjectSet = m_princessObjectSets[princessIndex];

        AudioSystem.Instance.PlayClickSound();

        HandlePair(m_currentObjectSet);

        m_pairButton.gameObject.FadeGroup(0f, 0.5f);

        m_princessToChooseEntity.InitializeSecondScenePairing();
        m_princeToChooseEntity.InitializeSecondScenePairing();

        m_princeToChooseEntity.transform.DOMove(m_princePositionToPair.position, 0.8f);
        m_princessToChooseEntity.transform.DOMove(m_princessPositionToPair.position, 0.8f);

        AudioSystem.Instance.PlayMarrySound();

        m_mainSystem.CreateGridObjects();

        await Task.Delay(1000);

        MarryThemPairsDissapearing();
    }

    private async void MarryThemPairsDissapearing()
    {
        m_heartEffect.Play();

        m_happilyEverAfterImage.sprite = m_currentObjectSet.HappilyEverAfterSceneSprite;

        await Task.Delay(1000);

        m_logoPlayNowButton.transform.DOMove(m_logoPlayNowNewButtonPosition.position, 1f);

        choosingPrincessFirstSceneGameObject.FadeGroup(0f, 1f);
        m_choosingPrincessFromSecondCanvas.gameObject.FadeGroup(0f, 1f);

        await Task.Delay(1000);

        m_cameraController.enabled = true;

        choosingPrincessFirstSceneGameObject.SetActive(false);
        m_choosingPrincessFromSecondCanvas.SetActive(false);

        m_framesEntitesGroup.SetActive(false);

        m_pairButton.gameObject.SetActive(false);
    }

    private void ChangePrincessRightSide()
    {
        m_princessToChooseEntity.ChangeToRight();
        m_arrowHandTutorial.StopTutorialHandAnimation();
        m_tutorialHandPairButton.gameObject.SetActive(true);
    }

    private void ChangePrincessLeftSide()
    {
        m_princessToChooseEntity.ChangeToLeft();
        m_arrowHandTutorial.StopTutorialHandAnimation();
        m_tutorialHandPairButton.gameObject.SetActive(true);
    }

    #endregion
}