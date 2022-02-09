using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingAI : MonoBehaviour {
    public float speed = 3.0f;
    public Transform[] patrolPoints;
    public float waitTime = 1.0f;

    // Warning: Enemy should not be at 0 index at start other this logic will not work properly
    int currentPointIndex = 0;
    bool once = false;

    private void Update() {
        if(transform.position != patrolPoints[currentPointIndex].position) {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        } else {
            if(once == false) {
                once = true;
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(waitTime);
        if(currentPointIndex < patrolPoints.Length - 1) {
            currentPointIndex++;
        } else {
            currentPointIndex = 0;
        }
        once = false;
    }
}
