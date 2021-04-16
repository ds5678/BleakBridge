using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

namespace BleakBridge
{
    public class Implementation : MelonMod
    {
        private static AssetBundle assetBundle;
        public override void OnApplicationStart()
        {
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
            LoadEmbeddedAssetBundle();
        }
        private static void LoadEmbeddedAssetBundle()
        {
            MemoryStream memoryStream;
            //Log(typeof(UpdateShootingStar).Assembly.GetManifestResourceNames().Length.ToString());
            //Log(Assembly.GetExecutingAssembly().GetManifestResourceNames().Length.ToString());
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BleakBridge.res.bridge"))
            {
                memoryStream = new MemoryStream((int)stream.Length);
                stream.CopyTo(memoryStream);
            }
            if (memoryStream.Length == 0)
            {
                throw new System.Exception("No data loaded!");
            }
            assetBundle = AssetBundle.LoadFromMemory(memoryStream.ToArray());
        }
        internal static GameObject GetPrefab()
		{
            return assetBundle?.LoadAsset<GameObject>("assets/Bridge.prefab");
		}
        internal static void CreateBridge()
		{
            GameObject prefab = GetPrefab();
            if (prefab is null) return;
            GameObject gameObject = GameObject.Instantiate(prefab);
            gameObject.transform.position = new Vector3(-408f, 31.9f, -569f);
        }
    }
}
