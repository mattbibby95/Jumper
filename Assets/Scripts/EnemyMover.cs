using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    public float maxSpeed, minSpeed;
    private bool movingLeft;
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        int randomDir = Random.Range(0, 2);
        Debug.Log(randomDir);
        if (randomDir == 0)
        {
            movingLeft = false;
        }
        else
        {
            movingLeft = true;
        }
        moveSpeed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (!(1.2 < pos.y))
        {
            if (pos.x > 1)
            {
                movingLeft = false;
            }
            if (pos.x < 0)
            {
                movingLeft = true;
            }
            if (movingLeft)
            {
                transform.Translate(1 * moveSpeed * Time.deltaTime, 0, 0);
            }
            if (!movingLeft)
            {
                transform.Translate(-1 * moveSpeed * Time.deltaTime, 0, 0);
            }
        }
    }
}
