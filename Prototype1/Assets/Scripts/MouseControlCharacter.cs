using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControlCharacter : MonoBehaviour
{
    GameObject g1;
    GameObject g2;
    bool mouseClickedOnce;
    bool mouseHasContent;
    // Start is called before the first frame update
    void Start()
    {
        mouseClickedOnce = false;
        mouseHasContent = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseClickedOnce = Input.GetMouseButtonDown(0);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Grid" && mouseClickedOnce)
        {
            
        }
        if (c.gameObject.tag == "OldMan" && mouseClickedOnce)
        {
            g1 = c.gameObject;
        }
        if (c.gameObject.tag == "Wolf" && mouseClickedOnce)
        {
            g1 = c.gameObject;
        }

        mouseClickedOnce = Input.GetMouseButtonUp(0);
    }
}
