using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody2D body;
    Animator animator;
    Vector2 movement;
    public float runSpeed = 100.0f;

    // Dashing variables
    bool isDashing = false;
    bool shouldCallDashCoroutine = false;
    public float startDashTime = 0.05f;
    public float dashSpeed = 25f;
    // Number of times player can dash per second.
    public float dashCooldown = 2f;
    float nextDashTime = 0f;

    void Start() {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(Time.time >= nextDashTime) {
            if(Input.GetKeyDown(KeyCode.X)) {
                nextDashTime = Time.time + dashCooldown;
                shouldCallDashCoroutine = true;
            }
        }
    }

    private void FixedUpdate() {
        if(!IsPlaying(animator, "Sword_attack") && !isDashing) {
            // body.MovePosition(body.position + (Time.fixedDeltaTime * runSpeed * movement));
            body.velocity = Time.fixedDeltaTime * runSpeed * (new Vector2(movement.x, movement.y));
        }

        if(shouldCallDashCoroutine) {
            StartCoroutine(DashForward());
            shouldCallDashCoroutine = false;
        }
    }

    bool IsPlaying(Animator anim, string stateName) {

        return anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f;
    }

    IEnumerator DashForward() {
        isDashing = true;
        body.velocity *=  dashSpeed;
        // body.AddForce(new Vector2(body.velocity.x, body.velocity.y)  * dashSpeed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(startDashTime);
        isDashing = false;
        body.velocity = new Vector2(0, 0);

    }
}