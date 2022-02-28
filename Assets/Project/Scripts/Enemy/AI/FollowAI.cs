using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour {
    public float speed = 3.0f;
    public Transform target;
    public float minimumDistance = 2.0f;
    public float maxDistanceToStartFollow = 10.0f;

    private void Update() {
        if(target == null) return;
        if(
            Vector2.Distance(transform.position, target.position) > minimumDistance &&
            Vector2.Distance(transform.position, target.position) < maxDistanceToStartFollow
        ) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        } else {
            GetComponent<EnemyMeleeAttack>().Attack();
        }
    }

    private void OnDrawGizmosSelected() {
        if(transform.position == null) {
            return;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, minimumDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxDistanceToStartFollow);
    }
}
