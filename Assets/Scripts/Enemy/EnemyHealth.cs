using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float totalHealth = 100f;
    float currentHealth;

    private void Start() {
        currentHealth = totalHealth;
    }
    public void TakeDamage(float attackStrength) {
        currentHealth -= attackStrength;

        // TODO: Play hurt animation

        if(currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        // TODO: Play animation using boolean.

        GetComponent<BoxCollider2D>().enabled = false;
        // TODO: Disable any other script for enemy behaviour.
        // TODO: Destroy game object after death animation is played.
        // Destroy(gameObject);
        this.enabled = false;
    }
}
