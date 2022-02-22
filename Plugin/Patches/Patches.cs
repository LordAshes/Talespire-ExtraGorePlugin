using BepInEx;
using HarmonyLib;

using System;
using System.Collections;
using UnityEngine;

namespace LordAshes
{
    [BepInDependency(AssetDataPlugin.Guid)]
    public partial class ExtraGorePlugin : BaseUnityPlugin
    {
        static ExtraGorePlugin self = null;
        static string guidEAR { get; set; }
        static string guidBodyAura { get; set; }
        static string guidFilter { get; set; }
        static string nameTexture { get; set; }

        static float displayTime { get; set; }

        [HarmonyPatch(typeof(Creature), "AttackTargetCreature", new Type[] { typeof(Vector3) })]
        public static class AttackTargetCreaturePatch
        {
            public static bool Prefix(Vector3 impactDir)
            {
                CreatureBoardAsset asset;
                CreaturePresenter.TryGetAsset(LocalClient.SelectedCreatureId, out asset);
                if (asset != null)
                {
                    Debug.Log("Extra Gore Plugin: Applying Gore");
                    self.StartCoroutine("ApplyGore", new object[] { asset });
                }
                else
                {
                    Debug.Log("Extra Gore Plugin: Invalid Target");
                }
                return true;
            }
        }

        private IEnumerator ApplyGore(object[] inputs)
        {
            CreatureGuid target = ((CreatureBoardAsset)inputs[0]).Creature.TargetCreature;
            AssetDataPlugin.SetInfo(CreatureGuid.Empty.ToString(), guidEAR + ".Aura.labloodfilter", guidFilter);
            AssetDataPlugin.SetInfo(target.ToString(), guidBodyAura, nameTexture, true);
            yield return new WaitForSeconds(displayTime);
            Debug.Log("Extra Gore Plugin: Removing Gore");
            AssetDataPlugin.ClearInfo(CreatureGuid.Empty.ToString(), guidEAR + ".Aura.labloodfilter");
            AssetDataPlugin.ClearInfo(target.ToString(), guidBodyAura, true);
        }
    }
}
