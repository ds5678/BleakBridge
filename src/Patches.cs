using Harmony;

namespace BleakBridge
{
    internal class Patches
    { 
        [HarmonyPatch(typeof(GameManager),"Awake")]
        internal static class SpawnBridge
        {
            private static void Postfix()
            {
                if(GameManager.m_ActiveScene == "CanneryRegion")
                {
                    Implementation.CreateBridge();
                    MelonLoader.MelonLogger.Log("Textured Bridge Spawned");
                }
            }
        }
    }
}
