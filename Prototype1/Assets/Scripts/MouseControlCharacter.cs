using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControlCharacter : MonoBehaviour
{
    GameObject g1;
    GameObject g2;
    bool mouseClicked;
    bool mouseHasContent;
    // Start is called before the first frame update
    void Start()
    {
        mouseClicked = false;
        mouseHasContent = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        c.gameObject
    }
}
