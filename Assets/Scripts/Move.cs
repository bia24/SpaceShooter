using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move: MonoBehaviour {

    public float speed = 10;
	// Use this for initialization
	void Start () {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
	}
	

}
