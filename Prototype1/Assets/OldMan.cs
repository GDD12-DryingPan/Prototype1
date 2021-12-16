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
}
