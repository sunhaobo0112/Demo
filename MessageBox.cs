using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipsCode
{
    coin,
    pickup,
    wrong,
    levelup,
    none
}

public class MessageBox : MonoBehaviour
{
    public static MessageBox _instance { get; private set; }

    private UILabel uilabel;
    private TweenScale tweenScale;
    public AudioClip coin;
    public AudioClip pickup;
    public AudioClip wrong;
    public AudioClip levelup;
    AudioSource audioSource;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        uilabel = transform.Find("Sprite/Label").GetComponent<UILabel>();
        tweenScale = this.GetComponent<TweenScale>();
        audioSource =this.GetComponent<AudioSource>();
        //this.gameObject.SetActive(false);
        tweenScale.PlayReverse();

    }
    public void ShowMessageBox(string stri,TipsCode tc)
    {
        this.gameObject.SetActive(true);
        tweenScale.PlayForward();
        uilabel.text = stri;

        switch (tc)
        {
            //sound effect
            case TipsCode.coin:
                audioSource.PlayOneShot(coin,1);
                break;
            case TipsCode.levelup:
                audioSource.PlayOneShot(levelup, 1);
                break;
            case TipsCode.pickup:
                audioSource.PlayOneShot(pickup, 1);
                break;
            case TipsCode.wrong:
                audioSource.PlayOneShot(wrong, 1);
                break;
            case TipsCode.none:
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
