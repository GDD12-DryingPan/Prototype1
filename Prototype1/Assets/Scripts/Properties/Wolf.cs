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
    void OnTriggerEnter(Collider c)
    {
        GameObject g = c.gameObject;

        if (g.tag == "Grid")
        {
            GridMechanic m = g.GetComponent<GridMechanic>();
            GameObject inside = m.gameObject1;
            if (inside.tag == "EmptyGrid")
            {
                m.gameObject1 = gameObject;
            }
        }
        else
        {
            if (g.tag == "OldMan")
            {

            }
        }

    }
}
