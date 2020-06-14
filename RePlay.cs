using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RePlay : MonoBehaviour
{
    private float timer = 0;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=3.0f)         
        {
            ReplayGame();
        }
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;                      
    }   
}
