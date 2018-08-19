using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// This script changes the background images.

public class BackgroundGenerator : MonoBehaviour {

    [SerializeField]
    UnityEngine.UI.Image background = null;
	// Use this for initialization
	void Awake () {
        images.Clear();
        LoadImagesFromResources();
        SetBackground();    
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}

    private void OnEnable()
    {
        SetBackground();
    }
    //Pass by reference jank method...
    [SerializeField]
    List<Sprite> images;
    
    //Sets background image to a random image amongst all the images in Assets/Resources/Backgrounds
    void SetBackground()
    {
        background.sprite = images[(int)Mathf.Floor(Random.Range(0, images.Count - 1))];
    }

    //Gets all images from some location on disk and assigns it to images. To Do Later
    void LoadImagesFromDisk()
    {

    }

    //Loads all Images from resources as sprites.
    void LoadImagesFromResources()
    {
        Object[] loadedimages = Resources.LoadAll("Backgrounds", typeof(Sprite));
        for (int i = 0; i < loadedimages.Length; i++)
        {
            images.Add((Sprite)loadedimages[i]);
        }
    }
}
