using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public LayerMask enemyLayers;
    public LayerMask playerLayers;

    public float damage = 20f;
    
    private void OnCollisionEnter2D(Collision2D other) {
        // TODO: Instantiate hit animation.
        // TODO: Desctroy hit animation.
        Destroy(gameObject);

        if (Utils.IsLayerInMask(other.gameObject.layer, enemyLayers)) {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
