using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject debugObj, player, bullet;
    public float shotForce, bulletSpeed, currentDamage, shotCooldown;
    private bool isShooting, firstTouch, onCooldown, leftedge, rightedge;
    private Vector3 shotDirection;
    private Rigidbody rb;

    void Start()
    {
        rb = player.GetComponent<Rigidbody>();

        firstTouch = true;

        onCooldown = leftedge = rightedge = false;
    }


    void Update()
    {

        checkOffScreen();

        if (Input.touchCount > 0 && !onCooldown)
        {

            // Delay shots to stop bullet spam
            onCooldown = true;
            Invoke("resetCooldown", shotCooldown);

            // Enable gravity after first touch event
            if (firstTouch)
            {
                firstTouch = false;
                rb.useGravity = true;
            }

            // Getting touch pos and spawning debug obj
            Touch touch = Input.GetTouch(0);
            Vector3 touchpos = touch.position;
            touchpos.z = 29;
            Vector3 worldpos = Camera.main.ScreenToWorldPoint(touchpos);
            debugObj.transform.position = new Vector3(worldpos.x, worldpos.y, -1);


            // Calculating vector between touch and player
            shotDirection = (player.transform.position - debugObj.transform.position).normalized;
            Debug.DrawRay(debugObj.transform.position, shotDirection, Color.blue);

            isShooting = true;

        }
    }

    // Apply physics in fixed so timestep doesn't screw things up
    void FixedUpdate()
    {

        if (leftedge)
        {
            leftedge = false;
            bounceBack(player.transform.right);
        }

        if (rightedge)
        {
            rightedge = false;
            bounceBack(player.transform.right * -1);
        }

        if (isShooting)
        {
            isShooting = false;
            playerJump();
            spawnBullet();
        }
    }

    // Just add force in the correct direction
    void playerJump()
    {

        rb.AddForce(shotDirection * shotForce);

    }

    // Spawn a bullet prefab, add force, set damage, destroy after 2 seconds
    void spawnBullet()
    {
        var bul = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        bul.GetComponent<Rigidbody>().AddForce((shotDirection * -1) * bulletSpeed);
        bul.GetComponent<BulletController>().damage = currentDamage;
        Destroy(bul, 2);
    }

    // Add force to push player back onto screen, call in fixedupdate
    void bounceBack(Vector3 direction)
    {
        Vector3 newVel = rb.velocity;
        newVel.x *= -1;
        rb.velocity = newVel;
    }

    // If player goes off screen set flags for processing
    void checkOffScreen()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0.0)
        {
            leftedge = true;
        }
        if (1.0 < pos.x)
        {
            rightedge = true;
        }
        if (pos.y < 0.0)
        {
            Debug.Log("Below Camera");
        }
        if (1.0 < pos.y)
        {
            Debug.Log("Above Camera");
        }
    }

    void resetCooldown()
    {
        onCooldown = false;
    }
}
