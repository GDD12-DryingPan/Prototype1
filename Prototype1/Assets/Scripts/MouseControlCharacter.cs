using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControlCharacter : MonoBehaviour
{
    GameObject g1;
    GameObject g2;
    bool mouseClickedOnce;
    bool mouseClickedTwice;
    bool mouseHasContent;
    // Start is called before the first frame update
    void Start()
    {
        mouseClickedOnce = false;
        mouseClickedTwice = false;
        mouseHasContent = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseClickedOnce && mouseHasContent)
        {
            mouseClickedTwice = true;
        }
        mouseClickedOnce = Input.GetMouseButtonDown(0);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Grid" && mouseClickedTwice)
        {
            c.gameObject.GetComponent<GridMechanic>().gameObject1 = g1;
            mouseClickedOnce = false;
            mouseClickedTwice = false;
            mouseHasContent = false;
        }
        if (c.gameObject.tag == "OldMan" && mouseClickedOnce)
        {
            g1 = c.gameObject;
            mouseHasContent = true;
        }
        // later
        if (c.gameObject.tag == "Wolf" && mouseClickedOnce)
        {
            g1 = c.gameObject;
        }

        mouseClickedOnce = Input.GetMouseButtonUp(0);
    }
}
