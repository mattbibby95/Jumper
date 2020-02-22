﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator spawnEnemy()
    {

        while (true)
        {
            Debug.Log("SPAWN");
            Vector3 spawnScreenPos = new Vector3(Random.Range(0, Screen.width), Screen.height, 31);
            Vector3 worldpos = Camera.main.ScreenToWorldPoint(spawnScreenPos);
            worldpos.z = -1;
            worldpos.y += 2;
            Instantiate(enemies[Random.Range(0, enemies.Length - 1)], worldpos, Quaternion.Euler(90, 0, 0));
            yield return new WaitForSeconds(Random.Range(0.1f, 3f));
        }

    }
}
