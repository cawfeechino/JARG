using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    [SerializeField] SpriteRenderer target;
    SpriteRenderer sr;
    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void ChangeColor()
    {
        sr.color = target.color;
    }

    public void Reverse()
    {
        sr.color = new Color(1,1,1);
    }
}