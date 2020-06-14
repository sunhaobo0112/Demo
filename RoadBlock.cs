using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlock : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == GameCommon.player)
        {
            MessageBox._instance.ShowMessageBox("特定の敵を倒して道を開きましょう！！", TipsCode.wrong);
        }
    }
}
