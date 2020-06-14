using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelTipsCode
{
    levelup
}

public class LevelMessageBox : MonoBehaviour
{
    public static LevelMessageBox _instance { get; private set; }

    private UILabel uilabel;
    private TweenScale tweenScale;
    public AudioClip levelup;
    AudioSource audioSource;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        uilabel = transform.Find("Label").GetComponent<UILabel>();
        tweenScale = this.GetComponent<TweenScale>();
        audioSource =this.GetComponent<AudioSource>();
        //this.gameObject.SetActive(false);
        tweenScale.PlayReverse();

    }
    public void ShowLevelMessageBox(string stri,TipsCode tc)
    {
        this.gameObject.SetActive(true);
        tweenScale.PlayForward();
        uilabel.text = stri;

        switch (tc)
        {
            //sound effect

            case TipsCode.levelup:
                audioSource.PlayOneShot(levelup, 1);
                break;

        }
        StartCoroutine(HideMessageBox());

    }

    IEnumerator HideMessageBox()
    {
        yield return new WaitForSeconds(2.0f);
        tweenScale.PlayReverse();
    }

}
