using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// This script changes the background images.

public class BackgroundGenerator : MonoBehaviour {

    [SerializeField]
    UnityEngine.UI.Image background = null;
	// Use this for initialization
	void Start () {
        //SetBackground();    
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}

    private void OnEnable()
    {
        StartCoroutine(ExecuteAfterTime(0.1f));
        
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SetBackground();
        // Code to execute after the delay
    }

    //Sets background image to a random image amongst all the images in Assets/Resources/Backgrounds
    void SetBackground()
    {
        int rand = (int)Mathf.Floor(Random.Range(0, Globals.BackgroundList.Count - 1));
        Debug.Log(Globals.BackgroundList.Count);
        background.sprite = Globals.BackgroundList[rand];
    }

    //Gets all images from some location on disk and assigns it to images. To Do Later
    void LoadImagesFromDisk()
    {

    }


}
