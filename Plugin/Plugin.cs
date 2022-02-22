using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System;
using UnityEngine;


namespace LordAshes
{
    [BepInPlugin(Guid, Name, Version)]
    [BepInDependency(FileAccessPlugin.Guid)]
    [BepInDependency(AssetDataPlugin.Guid)]
    public partial class ExtraGorePlugin : BaseUnityPlugin
    {
        // Plugin info
        public const string Name = "Extra Gore Plug-In";              
        public const string Guid = "org.lordashes.plugins.extragore";
        public const string Version = "1.0.0.0";                    

        void Awake()
        {
            UnityEngine.Debug.Log("Extra Gore Plugin: Active.");

            displayTime = Config.Bind("Settings", "Length In Seconds That Gore Is Displayed", 3.0f).Value;
            guidEAR = Config.Bind("Settings", "Extra Asset Registration Plugin Guid", "org.lordashes.plugins.extraassetsregistration").Value;
            guidBodyAura = Config.Bind("Settings", "Body Aura Plugin Guid", "org.lordashes.plugins.bodyaura").Value;
            guidFilter = Config.Bind("Settings", "Camera Filter Name", "3e736d60-d31a-1a34-177a-867319885255").Value;
            nameTexture = Config.Bind("Settings", "Body Aura Texture Name", "blood").Value;

            self = this;

            var harmony = new Harmony(Guid);
            harmony.PatchAll();

            Utility.PostOnMainPage(this.GetType());
        }
    }
}
