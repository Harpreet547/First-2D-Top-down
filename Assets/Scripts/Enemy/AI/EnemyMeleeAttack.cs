using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour {
    Animator anim;

    public float timeBtwAttacks = 2.0f;

    float nextAttackTime;

    private void Start() {
        anim = GetComponent<Animator>();
        nextAttackTime = Time.time + timeBtwAttacks;
    }

    public void Attack() {
        if(Time.time > nextAttackTime) {
            anim.SetTrigger("Attack");
            nextAttackTime = Time.time + timeBtwAttacks;
        }
    }
}
