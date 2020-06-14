using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskControl : MonoBehaviour
{
    void Start()
    {
        ClosePanel();
    }

    public void ClosePanel()
    {
        transform.parent.gameObject.SetActive(false);
    }
    public void ShowPanel()
    {
        transform.parent.gameObject.SetActive(true);
    }
}
