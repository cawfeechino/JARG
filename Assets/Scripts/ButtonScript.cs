using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class ButtonScript : MonoBehaviour {

    
    //Attach to Button UI
    [SerializeField]
    SongSelect sselect;
    // Update is called once per frame
    private void Start()
    {
        sselect = FindObjectOfType<SongSelect>();
    }
    void Update () {
		
	}
    public void OnSelection(Button button)
    {
        print(button.name);

    }
    public void OnClicked(Button button)
    {
        print("Go");

        print(Globals.SongList.Count);
        foreach (AudioClip song in Globals.SongList)
        {
            
            if (song.name == button.name)
            {
                Debug.Log("Same");
                print(song.name + " == " + button.name);
                sselect.GetComponent<AudioSource>().clip = song;
                sselect.gameObject.GetComponent<AudioSource>().Play();
                print("Audioplay");
                break;
            }
        }
        if(button == sselect.selected)
        {
            //Start Gameplay
            Debug.Log("Start Game");
            AudioClip s = Globals.SongList.Find(song => song.name == button.name);
            Debug.Log(s.name);
            Globals.CurrentSong = s;
            SceneManager.LoadScene(1);
        }
        else
        {

            sselect.selected = button;
        }

    }
}
