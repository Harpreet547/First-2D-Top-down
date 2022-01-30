using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    Animator animator;
    Rigidbody2D rb;

    void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Attack();
        }
    }

    void Attack() {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D hitEnemy in hitEnemies) {
            Debug.Log("We hit enemy: " + hitEnemy.name);
            // TODO: Damage enemy.
        };
    }

    private void OnDrawGizmosSelected() {
        if(attackPoint == null) {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
