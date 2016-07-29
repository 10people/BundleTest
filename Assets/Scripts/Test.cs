using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    public void DoIt()
    {
        var bundle = AssetBundle.LoadFromFile(Application.dataPath + "/AssetBundle/3d");
        var prefab = bundle.LoadAsset<GameObject>("Assets/Resources/Capsule.prefab");
        var temp = Instantiate(prefab);
    }

    void Start()
    {
        DoIt();
    }
}
