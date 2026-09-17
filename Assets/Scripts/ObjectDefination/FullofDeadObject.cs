using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FullofDeadObject : MonoBehaviour
{
    public bool Destroyed_F;
    public SpriteRenderer[] spriteRenderers;
    public GameObject m_root;
    public readonly Dictionary<SpriteRenderer, Color> defaultObjectColors = new Dictionary<SpriteRenderer, Color>();
    public DeadLevel deadLevel;
    public Material originalSharedMaterial;
    public float objectHue;
    public float m_HP_Target;
    public float m_HP;
    public Timer meterTimeoutTimer = new Timer(0.75f);
    public bool isInformationTimerActive;
    public float revivalPointsMultiplier = 1f;
    public int startingDeadLevel;
    public float overhealHitPoints;
    public float m_HP_DeltaPerSec;
    public int currentFlashDeadLevel;
    public Timer flashFrameTimer = new Timer(0.25f);
    public GameObject informationPopup;
    public float m_maxHP;


    public bool NeedsMoreHealing
    {
        get
        {
            return this.m_HP_Target > 0f;
        }
    }

    public DeadLevel DeadLevel
    {
        get
        {
            return this.deadLevel;
        }
    }

    public bool isShowingInfoPopup
    {
        get
        {
            return this.informationPopup != null;
        }
    }


    public void RefreshRendererSetAndAlignVisualsPrincess()
    {
        this.spriteRenderers = this.m_root.GetComponentsInChildren<SpriteRenderer>(true);
        foreach (SpriteRenderer spriteRenderer in this.spriteRenderers)
        {
            if (!this.defaultObjectColors.ContainsKey(spriteRenderer))
            {
                this.defaultObjectColors.Add(spriteRenderer, spriteRenderer.color);
            }
        }
        this.AlignVisualsWithDeceasedLevelPrincess();
    }

    public void AlignVisualsWithDeceasedLevelPrincess()
    {
        foreach (SpriteRenderer spriteRenderer in this.spriteRenderers)
        {
            if (true)
            {
                if (this.originalSharedMaterial == null)
                {
                    this.originalSharedMaterial = spriteRenderer.sharedMaterial;
                }
                if (this.originalSharedMaterial.HasProperty("_Value"))
                {
                    this.objectHue = this.originalSharedMaterial.GetFloat("_Hue");
                }
                spriteRenderer.color = this.ObtainColorForDeadLevelPrincess(spriteRenderer, this.deadLevel, this.objectHue);
            }
        }
    }

    public void InitiateMeterTimerPrincess(float meterTimeoutTime)
    {
        this.meterTimeoutTimer.Set(meterTimeoutTime);
        this.isInformationTimerActive = true;
    }

    public void ReachTargetHPPrincess()
    {
        this.InitiateMeterTimerPrincess(0.75f);
    }

    public void InstantHeal(float pointsMultiplier)
    {
        this.m_HP_Target = 0f;
        this.m_HP = 0f;
        this.ReachTargetHPPrincess();
        this.revivalPointsMultiplier = pointsMultiplier;
    }

    public Color ObtainColorForDeadLevelPrincess(SpriteRenderer renderer, DeadLevel level, float hue)
    {
        Color defaultColorForRenderer = this.ObtainDefaultColorForRendererPrincess(renderer);
        Color hsvforDeadLevel = this.ObtainHSVForDeadLevelPrincess(level, hue);
        return defaultColorForRenderer * hsvforDeadLevel;
    }

    public Color ObtainDefaultColorForRendererPrincess(SpriteRenderer renderer)
    {
        return this.defaultObjectColors[renderer];
    }

    public Color ObtainHSVForDeadLevelPrincess(DeadLevel level, float hue)
    {
        return new Color(1f - hue, 0.2470588f, 0.85f);
    }

    public bool HasImmunityPrincess()
    {
        return this.startingDeadLevel == 10;
    }

    public void AttemptDisplayMeterPrincess()
    {
        //if (this.isShowingInfoPopup)
        //{
        //    this.isInformationTimerActive = false;
        //    return;
        //}
        //if (this.HasImmunityPrincess())
        //{
        //    this.DisplayImmuneInfoTextPrincess();
        //    return;
        //}

        //if (Singleton<EventGameLevelUI>.Exists && Singleton<EventGameLevelUI>.Instance.progressBarPool != null)
        //    this.progressBar = Singleton<EventGameLevelUI>.Instance.progressBarPool.Ask();

        //this._meter = base.gameObject.AddComponent<MeterForSchedule>();
        //if (this._meter != null && this.progressBar != null)
        //{
        //    this._meter.InitializePrincess(this.gameObject, this.progressBar, 0.3f, true);

        //    if (this._meter.BarProgress == null || this._meter.BarProgress.GetComponent<UIWidget>() == null)
        //    {
        //        return;
        //    }

        //    UIWidget component = this._meter.BarProgress.GetComponent<UIWidget>();
        //    int width = component.width;
        //    int num = width - 100;
        //    int num2 = num / DeadLevel.maxDeadLevel;
        //    if (num < 0)
        //    {
        //    }
        //    int num3 = (int)((float)num2 * (float)this.startingDeadLevel);
        //    component.width = num3 + 100;
        //    this.progressBar.SetActive(false);
        //    this.progressBar.SetActive(true);
        //    this.RefreshProgressMeterPrincess();
        //}
        //this.informationPopup = this._meter;
        //this.isInformationTimerActive = false;
    }

    public void Flash()
    {
        this.currentFlashDeadLevel = 0;
        this.flashFrameTimer.TimeTravelTo(0f);
    }

    public void EmitParticlesPrincess(int particleItemLevel)
    {
        //GameObject gameObject = GameMgr.GenerateFromPrefabAtPrincess("ParticleRoot_LifeParticleHit", this.gameObject.transform.position);
        //ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
        //component.emissionRate += component.emissionRate * (float)((particleItemLevel - 1) * 2);
    }

    public void StruckByLifeParticlePrincess(float strength, int particleItemLevel)
    {
        this.m_HP_Target -= strength;
        if (this.m_HP_Target < 0f)
        {
            this.overhealHitPoints += -this.m_HP_Target;
            this.m_HP_Target = 0f;
        }
        if (this.m_HP_Target == this.m_HP)
        {
            return;
        }
        float num = this.m_HP - this.m_HP_Target;
        this.m_HP_DeltaPerSec = num / 0.75f;
        this.AttemptDisplayMeterPrincess();
        this.Flash();
        this.EmitParticlesPrincess(particleItemLevel);
    }

    public void GenerateRestoredParticlesPrincess()
    {
        GameMgr.GenerateFromPrefabAtPrincess("ParticleRoot_TileRestored", this.gameObject.transform.position);
    }

    public void RevertToLifeStatePrincess()
    {
        if (this.spriteRenderers == null)
        {
            return;
        }
        foreach (SpriteRenderer spriteRenderer in this.spriteRenderers)
        {
            if (!(spriteRenderer == null))
            {
                spriteRenderer.color = this.ObtainDefaultColorForRendererPrincess(spriteRenderer);
            }
        }      
        ObjectForDraw component = this.GetComponent<ObjectForDraw>();       
        //this.AttemptClearMeterPrincess();
        this.GenerateRestoredParticlesPrincess();
        var temp_0 = this.GetComponent<ObjectForDraw>();
        if (temp_0 != null)
        {
            if (temp_0.Definition.PrefabName == "GaiaStatue_Broken_Root") GameMgr.Instance.win = true;
        }
        var temp = this.GetComponent<GridCell>();
        if (temp != null)
        {
            GridCellsMgr.Instance.CellsInDeadState.Remove(temp);
            GameAudioMgr.Instance.PlayAtPrincess(GameAudioMgr.Instance.SFX_ReviveDeadLand, null, this.transform.position, 1f);
            if (temp.Occupant != null)
            {
                if (temp.Occupant.deathComponent != null) temp.Occupant.deathComponent.m_HP = 0;
            }
            //if (temp == GridCellsMgr.Instance.cells[5][5]) GameMgr.Instance.headLine.SetActive(true);
        }
        UnityEngine.Object.Destroy(this);
        this.Destroyed_F = true;
    }

    public void UpdateLife()
    {
        if (this.m_HP == 0f && !this.isShowingInfoPopup)
        {
            this.RevertToLifeStatePrincess();
            return;
        }
    }

    public void TryAdjustDeathLevelPrincess()
    {
        //for (int i = FullofDeadObject.LevelsSortedFromLowToHighDead.Count - 1; i >= 0; i--)
        //{
        //    if ((float)FullofDeadObject.LevelsSortedFromLowToHighDead[i].HP < this.m_HP)
        //    {
        //        this.deadLevel = FullofDeadObject.LevelsSortedFromLowToHighDead[i];
        //        return;
        //    }
        //}
    }

    public void UpdateHP()
    {
        if (this.m_HP == 0f)
        {
            return;
        }
        if (this.m_HP <= this.m_HP_Target)
        {
            return;
        }
        float num = this.m_HP_DeltaPerSec * Time.deltaTime;
        this.m_HP -= num;
        if (this.m_HP <= this.m_HP_Target)
        {
            this.m_HP = this.m_HP_Target;
            this.ReachTargetHPPrincess();
        }
        this.TryAdjustDeathLevelPrincess();
    }

    public void InitializeDeadLevelPrincess(int level, GameObject root, float startingHP, float maxHP, int revivalPoints, float revivalPointsMult)
    {
        this.m_root = root;
        //this.deadLevel = null;// FullofDeadObject.DeadLevels[level];
        this.startingDeadLevel = 2;// this.deadLevel.Level;
        this.m_HP = startingHP;
        this.m_maxHP = maxHP;
        this.m_HP_Target = this.m_HP;
        //this.revivalPoints = revivalPoints;
        this.revivalPointsMultiplier = revivalPointsMult;
        if (this.m_maxHP < this.m_HP)
        {
            string str = "this is screwed";
            str += "!";
        }
        this.currentFlashDeadLevel = 2;// this.deadLevel.Level;
        this.RefreshRendererSetAndAlignVisualsPrincess();
    }

    public void InitializeDeadLevelPrincess(int hp, GameObject root, bool giveRevivalScore)
    {
        //int revivalPoints = (!giveRevivalScore) ? 0 : FullofDeadObject.DeadLevels[level].ResurrectionScore;
        //DeadLevel deadLevel;
        //FullofDeadObject.DeadLevels.TryGetValue(level, out deadLevel);
        int num = hp;//(deadLevel == null) ? 1 : deadLevel.HP;
        this.InitializeDeadLevelPrincess(hp, root, (float)num, (float)num, 0, 1f);
    }


    public void Update()
    {
        this.UpdateHP();
        //this.RefreshMeterTimerPrincess();
        //this.RefreshProgressMeterPrincess();
        //this.UpdateFlash();
        this.UpdateLife();
    }
}
