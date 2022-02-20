using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAndArrow : MonoBehaviour {
    public Transform shootingPoint;
    public GameObject arrowPrefab;
    public float force = 20.0f;
    public int totalArrows = 10;
    public float shootCooldown = 0.5f;

    private int remainingArrows;
    private float nextShootTime = 0.0f;

    private void Start() {
        remainingArrows = totalArrows;
    }

    void Update() {
        if(Time.time >= nextShootTime) {
            if(Input.GetButtonDown("Fire1")) {
                if(remainingArrows > 0) {
                    Shoot();
                    nextShootTime = Time.time + shootCooldown;
                }
            }
        }
    }

    void Shoot() {
        remainingArrows--;
        GameObject arrow = Instantiate(arrowPrefab, shootingPoint.position, shootingPoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(shootingPoint.up * force, ForceMode2D.Impulse);
    }
}