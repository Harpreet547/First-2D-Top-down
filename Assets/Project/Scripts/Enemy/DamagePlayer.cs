using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
    public LayerMask playerLayers;
    public bool shouldDestroySelf = true;

    public float damage = 20f;
    
    private void OnCollisionEnter2D(Collision2D other) {
        // TODO: Instantiate hit animation.
        // TODO: Desctroy hit animation.
        OnCollision(other.collider);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        OnCollision(other);
    }

    void OnCollision(Collider2D other) {
        if(shouldDestroySelf) Destroy(gameObject);
        if (Utils.IsLayerInMask(other.gameObject.layer, playerLayers)) {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
