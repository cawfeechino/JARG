using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main : MonoBehaviour {

    // Use this for initialization
    SongSelect ss;
    MainMenu title;
    private static bool created = false;

    //Initialization process
    //Only needs to to this once when application starts up
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
        LoadSongsFromResources();
        LoadImagesFromResources();
        LoadSongChartFromResources();
        Debug.Log("Background Count: " + Globals.BackgroundList.Count);
        Debug.Log("Song Count: " + Globals.SongList.Count);
        Debug.Log("Charts Count: " + Globals.ChartsList.Count);
    }
    private void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
        created = true;
        Debug.Log("Awake: " + this.gameObject);
        
    }
    void LoadSongsFromResources()
    {
        Object[] loadedsongs = Resources.LoadAll("Music", typeof(AudioClip));
        for (int i = 0; i < loadedsongs.Length; i++)
        {
            Globals.SongList.Add((AudioClip)loadedsongs[i]);
        }

    }
    //Loads all Images from resources as sprites.
    void LoadImagesFromResources()
    {
        Object[] loadedimages = Resources.LoadAll("Backgrounds", typeof(Sprite));
        for (int i = 0; i < loadedimages.Length; i++)
        {
            Globals.BackgroundList.Add((Sprite)loadedimages[i]);
        }
    }
    void LoadSongChartFromResources()
    {
        Object[] loadedChart = Resources.LoadAll("Charts", typeof(GameObject));
        for (int i = 0; i < loadedChart.Length; i++)
        {
            Globals.ChartsList.Add((GameObject)loadedChart[i]);
        }
    }
    public bool gameStarted;
    [SerializeField] bool stop;
    private void Update()
    {
        if(!GetComponent<AudioSource>().isPlaying && gameStarted)
        {
            SceneManager.LoadScene(0);
            Destroy(this.gameObject);
        }
        else if(GetComponent<AudioSource>().isPlaying && gameStarted && Input.GetKeyDown(KeyCode.Escape))
        {
            stop = true;
        }
        if(stop)
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}
