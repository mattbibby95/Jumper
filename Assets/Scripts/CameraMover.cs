﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    public float cameraSpeed = 1.5f;
    public float maxSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cameraSpeed < maxSpeed)
        {
            cameraSpeed *= 1.0001f;
        }
        transform.Translate(Vector3.up * Time.deltaTime * cameraSpeed);
    }
}
