using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager instance;

    public Texture2D normal;
    public Texture2D attack;
    public Texture2D talk;

    private Vector2 spot = Vector2.zero;
    CursorMode cm = CursorMode.Auto;

    private void Awake()
    {
        instance = this;
    }

    public void SetNormal()
    {
        Cursor.SetCursor(normal, spot, cm);
    }

    public void SetAttack()
    {
        Cursor.SetCursor(attack, spot, cm);
    }

    public void SetTalk()
    {
        Cursor.SetCursor(talk, spot, cm);
    }

}
