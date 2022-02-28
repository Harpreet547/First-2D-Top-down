using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMySelf : MonoBehaviour {
    public Camera cam;
    void Update() {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if(
            screenPosition.y > Screen.height ||
            screenPosition.y < 0 ||
            screenPosition.x > Screen.width ||
            screenPosition.x < 0
        ) {
            Destroy(this.gameObject);
        }
    }
}