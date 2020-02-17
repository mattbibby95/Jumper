using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    public float cameraSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cameraSpeed < 2.5)
        {
            cameraSpeed *= 1.0001f;
        }
        transform.Translate(Vector3.up * Time.deltaTime * cameraSpeed);
    }
}
