using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SongSelect : MonoBehaviour {

    //Reference to the content display
    //Attach to Canvas
    public GameObject content;

    public AudioClip[] Songs;
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
        LoadSongsFromResources();
        Song[] songlist = ParseSongs();
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
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(width, Mathf.Max(2560, songlist.Length * 500));

        Debug.Log(Songs.Length);
    }

    void Update () {
        //Android Back Button Event
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            m.gameObject.SetActive(true);            
        }
    }
    void LoadSongsFromResources()
    {
        Object[] loadedsongs = Resources.LoadAll("Music", typeof(AudioClip));
        Songs = new AudioClip[loadedsongs.Length];
        for (int i = 0; i < loadedsongs.Length; i++)
        {
            Songs[i] = (AudioClip)loadedsongs[i];
        }
        
    }
    Song[] ParseSongs()
    {
        Song[] s = new Song[Songs.Length];
        for (int i = 0; i <Songs.Length; i++)
        {
            
            
            string[] uta = Songs[i].name.Split('-');
            s[i].title = uta[0];
            s[i].artist = uta[1];
            s[i].name = Songs[i].name;
            Debug.Log(s[i].title + " - " + s[i].artist);
        }
        return s;
    }
    


}
