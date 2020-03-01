using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float damage;
    public float ttl = 15;
    public GameObject explEffect;

    private IEnumerator bulDestroy()
    {
        yield return new WaitForSeconds(ttl);
        var particle = Instantiate(explEffect, transform.position, Quaternion.identity);
        Destroy(particle, 1f);
        Destroy(gameObject);

    }

    private void Start()
    {
        StartCoroutine("bulDestroy");
    }

}
