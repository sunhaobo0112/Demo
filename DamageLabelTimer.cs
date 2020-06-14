using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLabelTimer : MonoBehaviour
{
    private float timer;
    private bool isStart = false;

    void Start()
    {
        timer = 0;
        isStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>0.9f)
        {
            timer = 0;
            this.gameObject.SetActive(false);
        }
    }
}
