using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndRetreat : MonoBehaviour {
    public float speed = 3.0f;
    public Transform target;
    public float minimumDistance = 2.0f;
    public GameObject projectile;
    public float timeBtwShoots = 1.0f;
    public float shootForce = 2.0f;

    private float nextShotTime;

    private void Update() {

        if(Time.time > nextShotTime) {
            Shoot();
            nextShotTime = Time.time + timeBtwShoots;
        }

        if(Vector2.Distance(transform.position, target.position) < minimumDistance) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
    }

    private void Shoot() {
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce((target.position - transform.position) * shootForce, ForceMode2D.Impulse);
    }

    private void OnDrawGizmosSelected() {
        if(transform.position == null) {
            return;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, minimumDistance);

    }
}
