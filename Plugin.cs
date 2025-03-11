using System;
using System.IO;
using BepInEx;
using EntityStates;
using EntityStates.Huntress;
using EntityStates.Huntress.HuntressWeapon;
using EntityStates.Huntress.Weapon;
using R2API;
using RoR2;
using UnityEngine;

namespace MAGICALGIRLHUNTRESS;

    [BepInPlugin("com.XO.MagicalGirlHuntress", "MAGICALGIRLHUNTRESS", "1.0.0")]
    public class MagicalHuntPlugin : BaseUnityPlugin
    {
  
        public static MagicalHuntPlugin instance { get; private set; }

       
        public void Awake()
        {
        LoadAndRegisterAssets();
        RoR2Application.onLoad += ReplaceVanillaAssets

        }

    private void LoadAndRegisterAssets()
    {
        var path = System.IO.Path.GetDirectoryName(this.Info.Location);
        this.mainBundle = AssetBundle.LoadFromFile(System.IO.Path.Combine(path, MAGICALGIRLHUNTRESS));

        this.OmniImpactVFXHuntress = this.mainBundle.LoadAsset<GameObject>("MAGICALGIRLHUNTRESS");
        R2API.ContentAddition.AddEffect(this.OmniImpactVFXHuntress);

        this.HuntressFireArrowRain = this.mainBundle.LoadAsset<GameObject>("MAGICALGIRLHUNTRESS");
        R2API.ContentAddition.AddEffect(this.HuntressFireArrowRain);

        this.TracerHuntressSnipe = this.mainBundle.LoadAsset<GameObject>("MAGICALGIRLHUNTRESS");
        R2API.ContentAddition.AddEffect(this.TracerHuntressSnipe);

    }

        private void ReplaceVanillaAssets()
        {
           EntityState.Huntress.BlinkState.blinkPrefab = this.blinkEffect;
            EntityState.Huntress.BeginArrowSnipe.blinkPrefab = this.blinkEffect;
            EntityState.Huntress.GenericBulletBaseState.hitEffectPrefab = this.OmniImpactVFXHuntress;
            EntityState.Huntress.GenericBulletBaseState.muzzleFlashPrefab = this.HuntressFireArrowRain;
           EntityState.Huntress.GenericBulletBaseState.tracerEffectPrefab = this.TracerHuntressSnipe;
 

        }


        public const string PluginGUID = "com.XO.MagicalGirlHuntress";

        public const string PluginAuthor = "XO";

       
        public const string PluginName = "MagicalGirlHuntress";

       
        public const string PluginVersion = "1.0.0";

        
        private AssetBundle mainBundle;

       
        private const string bundleName = "MAGICALGIRLHUNTRESS";


    private GameObject blinkEffect;
    private GameObject OmniImpactVFXHuntress;
    private GameObject HuntressFireArrowRain;
    private GameObject TracerHuntressSnipe;
    }
}

