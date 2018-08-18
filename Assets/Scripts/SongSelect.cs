using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelect : MonoBehaviour {

    //Reference to the content display
    [SerializeField]
    GameObject content;

    [SerializeField]
    AudioClip[] Songs;

	void Start () {
        LoadSongsFromResources();
	}
    	
	void Update () {
		
	}
    void LoadSongsFromResources()
    {
        Object[] loadedsongs = Resources.LoadAll("Music", typeof(AudioClip));
        Songs = new AudioClip[loadedsongs.Length];
        for (int i = 0; i < loadedsongs.Length; i++)
        {
            Songs[i] = (AudioClip)loadedsongs[i];
        }
        foreach(AudioClip a in Songs)
        {
            Debug.Log(a.name);
        }
    }
    void ParseSongs()
    {

    }
    
}
