using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public GameObject player;

    private Transform playerTransform;

    public float distanceScore;
    public float levelIncrement = 100f;

    private float nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        distanceScore = -100f;
        playerTransform = player.GetComponent<Transform>();
        nextLevel = levelIncrement;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y > distanceScore)
        {
            distanceScore = playerTransform.position.y;
        }
        if (distanceScore >= nextLevel)
        {
            Debug.Log("REACHED DISTANCE: " + nextLevel);
            nextLevel += levelIncrement;
        }
    }
}
