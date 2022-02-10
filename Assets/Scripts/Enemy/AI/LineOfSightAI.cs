using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSightAI : MonoBehaviour {
    public float rotationSpeed = 35.0f;
    public float visionDistance = 4.0f;
    public Transform shootingPoint;
    public LineRenderer lineOfSight;

    private void Update() {
        // Start position of line
        lineOfSight.SetPosition(0, shootingPoint.position);

        transform.Rotate(Time.deltaTime * rotationSpeed * Vector3.forward);

        RaycastHit2D hitInfo = Physics2D.Raycast(shootingPoint.position, -shootingPoint.up, visionDistance);
        if(hitInfo.collider != null) {
            Debug.DrawLine(shootingPoint.position, hitInfo.point, Color.red);

            lineOfSight.SetPosition(1, hitInfo.point);
            lineOfSight.startColor = Color.red;
            lineOfSight.endColor = Color.red;

            // TODO: Check if collided object is player.
        } else {
            Debug.DrawLine(shootingPoint.position, shootingPoint.position - shootingPoint.up * visionDistance, Color.green);

            lineOfSight.SetPosition(1, shootingPoint.position - shootingPoint.up * visionDistance);
            lineOfSight.startColor = Color.green;
            lineOfSight.endColor = Color.green;
        }
    }
}
