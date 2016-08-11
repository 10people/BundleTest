using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    public ConfigManager m_ConfigManager = new ConfigManager();

    IEnumerator Start()
    {
        if (m_ConfigManager.LoadConfig())
        {
            if (m_ConfigManager.IsCleanCache)
            {
                Caching.CleanCache();
            }

            //var bundle = AssetBundle.LoadFromFile(Application.dataPath + "/AssetBundle/3d");
            WWW www = WWW.LoadFromCacheOrDownload("file:///" + "C:/SVNs/BundleTest/Assets/AssetBundle/3d", m_ConfigManager.TargetBundleVersion);
            //WWW www = new WWW("file:///" + Application.dataPath + "/AssetBundle/3d");
            yield return www;

            var bundle = www.assetBundle;
            var prefab = bundle.LoadAsset<GameObject>("Assets/Prefabs/Capsule.prefab");
            var temp = Instantiate(prefab);
        }
    }
}
