using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    public GameObject enemyBullet;
    private GameObject player;
    public float bulletSpeed;
    public float minimumDelay;
    public float maximumDelay;
    public float accuracy;
    private Vector3 shotDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(shoot());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator shoot()
    {
        while (true)
        {
            shotDirection = (gameObject.transform.position - player.transform.position).normalized;
            shotDirection = Quaternion.AngleAxis(Random.Range(-accuracy, accuracy), Vector3.forward) * shotDirection;
            var bul = Instantiate(enemyBullet, gameObject.transform.position, Quaternion.identity);
            bul.GetComponent<Rigidbody>().AddForce(shotDirection * bulletSpeed * -1);
            Destroy(bul, 15f);
            yield return new WaitForSeconds(Random.Range(minimumDelay, maximumDelay));
        }
    }
}
