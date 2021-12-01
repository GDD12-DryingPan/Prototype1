using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMechanic : MonoBehaviour
{
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        gameObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject == null)
        {
            // do nothing
        }
    }
}
