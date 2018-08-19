using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

    // Use this for initialization
    public float time;
    float init;
    AudioSource source;
	void Awake () {
        init = time;
        this.GetComponent<Text>().text = time.ToString();
        source = FindObjectOfType<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if(time >= 0)
        {
            time -= Time.deltaTime;
            this.GetComponent<Text>().text = time.ToString();
        }
        

        if(time < 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        time = init;
    }
    private void OnDisable()
    {
        SetSong();
    }
    public void SetSong()
    {
        GameObject chart = Globals.ChartsList.Find(c => c.name == Globals.CurrentSong.name);
        Debug.Log(chart);
        if(chart == null)
        {
            return;
        }
        Instantiate(chart);
        source.clip = Globals.CurrentSong;
        source.Play();
        source.GetComponent<Main>().gameStarted = true;
        Debug.Log("Spawn Chart");
    }
}
