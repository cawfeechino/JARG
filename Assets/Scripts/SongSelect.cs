using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SongSelect : MonoBehaviour {

    //Reference to the content display
    //Attach to Canvas
    public GameObject content;

    //public AudioClip[] Songs;
    //Song Button Prefab
    [SerializeField]
    GameObject clone;

    public Button selected = null;

    public struct Song
    {
        public string title, artist, name;

        public Song(string t, string a, string n)
        {
            title = t;
            artist = a;
            name = n;
        }
    }
    MainMenu m;
    void Start () {
        m = FindObjectOfType<MainMenu>();
        //LoadSongsFromResources();
        List<Song> songlist = ParseSongs();
        var rectTransform = content.GetComponent<RectTransform>();
        float width = rectTransform.sizeDelta.x;
        foreach (Song s in songlist)
        {
            RectTransform rt = content.GetComponent<RectTransform>();
            GameObject child = Instantiate(clone);
            child.transform.SetParent(content.transform);
            child.transform.localScale = Vector3.one;
            child.GetComponentInChildren<Text>().text = s.title + "\n" + s.artist;
            child.name = s.name;
        }
        //Expands Content window to fit 
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(width, Mathf.Max(2560, songlist.Count * 500));
    }

    void Update () {
        //Android Back Button Event
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            m.gameObject.SetActive(true);            
        }
    }
    //void LoadSongsFromResources()
    //{
    //    Object[] loadedsongs = Resources.LoadAll("Music", typeof(AudioClip));
    //    Songs = new AudioClip[loadedsongs.Length];
    //    for (int i = 0; i < loadedsongs.Length; i++)
    //    {
    //        Songs[i] = (AudioClip)loadedsongs[i];
    //    }
        
    //}
    List<Song> ParseSongs()
    {
        List<Song> s = new List<Song>();
        for (int i = 0; i < Globals.SongList.Count; i++)
        {
            
            string[] uta = Globals.SongList[i].name.Split('-');
            s.Add(new Song(uta[0], uta[1], Globals.SongList[i].name));
            Debug.Log(s[i].title + " - " + s[i].artist);
        }
        return s;
    }
    


}
