using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using UnityEngine;

namespace BleakBridge
{
    internal class Patches
    { 
        [HarmonyPatch(typeof(SceneManager),"OnSceneLoaded")]
        internal static class SpawnBridge
        {
            private static void Postfix()
            {
                if(GameManager.m_ActiveScene == "CanneryRegion")
                {
                    BlockUtils.createBlocks();
                    MelonLoader.MelonLogger.Log("Block Bridge Spawned");
                }
            }
        }
    }
}
