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

}
