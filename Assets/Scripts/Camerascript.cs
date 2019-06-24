﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour
{
    // https://answers.unity.com/questions/149022/how-to-make-camera-move-with-the-mouse-cursors.html


    public float sensitivity;
    Camera mycam;
    // Start is called before the first frame update
    void Start()
    {
        mycam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vp = mycam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mycam.nearClipPlane));
        vp.x -= 0.5f;
        vp.y -= 0.5f;
        vp.x *= sensitivity;
        vp.y *= sensitivity;
        vp.x += 0.5f;
        vp.y += 0.5f;
        Vector3 sp = mycam.ViewportToScreenPoint(vp);

        Vector3 v = mycam.ScreenToWorldPoint(sp);
        transform.LookAt(v, Vector3.up);
    }
}
