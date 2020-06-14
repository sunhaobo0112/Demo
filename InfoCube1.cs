using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCube1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == GameCommon.player)
        {
            MessageBox._instance.ShowMessageBox("この先の敵は強くなる、慎重に進もう!", TipsCode.none);
        }
        Destroy(this);
    }
}
