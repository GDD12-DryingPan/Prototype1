using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // load MouseControlCharacter by looking for it with tag
        //
        // check if it carries gameobject
        //
        // get gameObject
        //
        // feed to coliding tile while clicking
    }

    void FixedUpdate()
    {
        transform.position = Input.mousePosition;
    }
}
