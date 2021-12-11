using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMan : MonoBehaviour 
{
    public GameObject characterProperties;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(characterProperties, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // in case the old man is inside the attack box collider of collides with anything else
    void OnTriggerEnter2D(Collider2D c)
    {

    }
}
