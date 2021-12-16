using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour

    // we can load in the behavior scripts here so the wolf script knows what atk and health it has. 
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this is for when the wolf gets attacked
    void OnTriggerEnter2D(Collider2D c)
    {
        GameObject g = c.gameObject;

        // my brain blank
        // this needs to be edited to fit the situation

        // old man needs to have his attributes added by hand!
    }
}
