using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour {

    public float tumble = 5f;
	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
	}

}
