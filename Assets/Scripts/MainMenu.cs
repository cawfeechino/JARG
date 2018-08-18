using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    

    //Contains references to all menu objects
    [SerializeField]
    GameObject[] MenuObjects;
    
	void Start () {
        StartCoroutine(flashobject());
	}
	
	// Update is called once per frame
	void Update () {
        //When detects user touches it closes the title screen.
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            //Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            this.gameObject.SetActive(false);
        }
        //Android Back Button Event
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //Function makes referenced menu objects blink in an out.
    IEnumerator flashobject()
    {
        while(true)
        {
            foreach (GameObject g in MenuObjects)
            {
                if (g.tag == "Blinking")
                {
                    g.SetActive(false);
                }
            }
            yield return new WaitForSeconds(0.5f);
            foreach (GameObject g in MenuObjects)
            {
                if (g.tag == "Blinking")
                {
                    g.SetActive(true);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
