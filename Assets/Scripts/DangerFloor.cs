using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerFloor : MonoBehaviour
{

    private Vector3 screenBottom, worldPos;
    public float smooth = 5f;
    public GameObject floorModel;
    private float maxY = -100f;

    void Start()
    {
        screenBottom = new Vector3(Screen.width / 2, 0, 31);

    }

    void Update()
    {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(screenBottom);
        stageDimensions.y += 2;
        if (stageDimensions.y > maxY)
        {
            maxY = stageDimensions.y;
            transform.position = Vector3.Lerp(transform.position, stageDimensions, Time.deltaTime * smooth);
        }
    }


}
