using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    private float speed = 0.9f;

    private float distance;
    private float scrollSpeed = 4;
    private float rotateSpeed = 2;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag(GameCommon.player).transform;
        }
        offset = player.position - transform.position;
    }

    void Update()
    {
        transform.position = player.position - offset;
        RotateView();
        ZoomView();
    }
    void ZoomView()
    {
        distance = offset.magnitude;
        distance += Input.GetAxis("Mouse ScrollWheel") * -scrollSpeed;
        distance = Mathf.Clamp(distance, 2, 10);
        offset = distance * offset.normalized;
    }
    void RotateView()
    {
        if (Input.GetMouseButton(1))
        {
            //Horizontal
            transform.RotateAround(player.position,player.up,Input.GetAxis("Mouse X")*rotateSpeed);
            //position ram and rotation
            Vector3 tempPos = transform.position;
            Quaternion tempRota = transform.rotation;
            transform.RotateAround(player.position,transform.right,-Input.GetAxis("Mouse Y")*rotateSpeed);
            float value = transform.eulerAngles.x;
            if (value < 0 || value > 70)
            {
                //do not ever rotate
                transform.position = tempPos;
                transform.rotation = tempRota;
            }
        }
        offset = player.position - transform.position;
    }
}
