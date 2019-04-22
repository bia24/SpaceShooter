using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_enemy_bolt : MonoBehaviour {

    public float speed = 10f;
    
    // Use this for initialization
	void Start () {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.velocity = speed * (new Vector3(0, 0, -1));
	}

}
