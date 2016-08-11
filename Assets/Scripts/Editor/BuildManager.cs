using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;

public class BuildManager
{
    private const string AssetBundlePath = "Assets/AssetBundle";

    [MenuItem("AssetBundle/Build")]
    public static void BuildAssetBundle()
    {
        AssetBundleBuild[] buildMap = new AssetBundleBuild[2];

        buildMap[0].assetBundleName = "3D";
        buildMap[0].assetNames = new string[] { "Assets/Prefabs/Capsule.prefab", "Assets/Prefabs/Cube.prefab", "Assets/Resources/Capsule.prefab" };

        buildMap[1].assetBundleName = "2D";
        buildMap[1].assetNames = new string[] { "Assets/Prefabs/Plane.prefab" };

        if (!Directory.Exists(AssetBundlePath))
        {
            Directory.CreateDirectory(AssetBundlePath);
        }
        Util.DeleteAll(AssetBundlePath);

        BuildPipeline.BuildAssetBundles(AssetBundlePath, buildMap, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
