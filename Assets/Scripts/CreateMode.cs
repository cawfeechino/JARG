using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMode : MonoBehaviour {

    public GameObject note;
    public bool createMode;
    public KeyCode key;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (createMode)
            if (Input.GetKeyDown(key))
                Instantiate(note, transform.position, Quaternion.identity);
    }
}
