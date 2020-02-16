using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpinner : MonoBehaviour
{

    public float xrot, yrot, zrot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xrot * Time.deltaTime, yrot * Time.deltaTime, zrot * Time.deltaTime);
    }
}
