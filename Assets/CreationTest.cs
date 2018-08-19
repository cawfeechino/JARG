using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationTest : MonoBehaviour {

    public Rigidbody2D note;
    public Transform location;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Instantiate(note, location.position, location.rotation);
	}
}
