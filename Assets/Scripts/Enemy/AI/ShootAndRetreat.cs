using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndRetreat : MonoBehaviour {
    public float speed = 3.0f;
    public Transform target;
    public float minimumDistance = 2.0f;
    public float minimumDistanceToShoot = 5.0f;
    public GameObject projectile;
    public float timeBtwShoots = 1.0f;
    public float shootForce = 2.0f;
    public Transform shootingPoint;
    public bool shouldRetreat = true;
    private float nextShotTime;
    Rigidbody2D rigidBody;

    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        nextShotTime = Time.time + timeBtwShoots;
    }

    private void Update() {

        if(Vector2.Distance(transform.position, target.position) < minimumDistance && shouldRetreat) {
            // Warning: Using transform.position will cause enemy to move through colliders. Use velocity if you don't want this.
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
    }

    private void FixedUpdate() {
        if(Time.time > nextShotTime && Vector2.Distance(transform.position, target.position) < minimumDistanceToShoot) {
            Shoot();
            nextShotTime = Time.time + timeBtwShoots;
        }

        // TODO: Refactor below logic
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Time.deltaTime * Mathf.Rad2Deg + 90;
        rigidBody.rotation = angle;
    }

    private void Shoot() {
        GameObject bullet = Instantiate(projectile, shootingPoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce((target.position - shootingPoint.position).normalized * shootForce, ForceMode2D.Impulse);
    }

    private void OnDrawGizmosSelected() {
        if(transform.position == null) {
            return;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, minimumDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, minimumDistanceToShoot);

    }
}
