using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLabel : MonoBehaviour
{
    public static DamageLabel instance { get; private set; }
    private UILabel damageLabel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        damageLabel = this.GetComponent<UILabel>();
        gameObject.SetActive(false);
    }

    public void Show(float value)
    {
        gameObject.SetActive(true);
        damageLabel.text = "-" + value;//value.Tostring();/+"";
    }


}
