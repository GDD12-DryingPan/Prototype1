using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{

    public AudioSource song;
    // Start is called before the first frame update
    void Start()
    {
        song.Play(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
