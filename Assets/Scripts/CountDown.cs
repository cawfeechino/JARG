using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

    //Simple Timer Script that will disable the gameobject it is attached to when the timer finishes
    //In editor set set the count variable to desired time.
    //When reenabling this gameobject the count will reset and start counting down again.
    public float count;
    float init;
	void Start () {
        init = count;
	}
	
	void Update () {
        count -= Time.deltaTime;
        if(count < 0)
        {
            gameObject.SetActive(false);
        }
	}
    private void OnEnable()
    {
        count = init;
    }
}
