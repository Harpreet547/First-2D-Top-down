using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {
    public LayerMask playerLayers;

    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (Utils.IsLayerInMask(other.gameObject.layer, playerLayers)) {
            // TODO: Damage player
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            // hitPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (rb.isKinematic) {
            Debug.Log(Utils.IsLayerInMask(other.gameObject.layer, playerLayers));
            rb.isKinematic = false;
        }
    }
}
