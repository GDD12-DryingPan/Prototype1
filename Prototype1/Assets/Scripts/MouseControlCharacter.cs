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
        Debug.Log("entered Start method at MouseControlCharacter");
        mouseClickedOnce = false;
        mouseClickedTwice = false;
        mouseHasContent = false;
    }

    // Update is called once per frame
    void Update()
    {
        // works
        if (mouseClickedOnce)
            Debug.Log("Registered MouseClick by boolean mouseClickedOnce");
        if (mouseClickedOnce && mouseHasContent)
        {
            // Mouse has content doesnt work!
            Debug.Log("Mouse Has Content");
            mouseClickedTwice = true;
        }
        mouseClickedOnce = Input.GetMouseButtonDown(0);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Grid" && mouseClickedTwice)
        {
            Debug.Log("Clicked Grid after clicked on Character");
            c.gameObject.GetComponent<GridMechanic>().gameObject1 = g1;
            mouseClickedOnce = false;
            mouseClickedTwice = false;
            mouseHasContent = false;
        }
        if (c.gameObject.tag == "OldMan" && mouseClickedOnce)
        {
            Debug.Log("You selected the old man.");
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
