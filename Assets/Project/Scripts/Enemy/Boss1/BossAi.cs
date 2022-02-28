using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi : MonoBehaviour {

    private ShootAndRetreatBehaviour shootAndRetreatBehaviour;

    private void Start() {
        shootAndRetreatBehaviour = GetComponent<ShootAndRetreatBehaviour>();
    }
    private void Update() {
        shootAndRetreatBehaviour.BehaviourOn_Update();
    }

    private void FixedUpdate() {
        shootAndRetreatBehaviour.BehaviourOn_FixedUpdate();
    }
}
