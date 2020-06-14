using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM instance { get; private set; }

    public GameObject slow;
    public GameObject quick;

    private void Awake()
    {
        instance = this;
    }


    public void ChangeBGM()
    {
        slow.gameObject.SetActive(false);
        quick.gameObject.SetActive(true);
    }
}
