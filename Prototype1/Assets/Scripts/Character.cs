using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool IsEnemy = false;
    public Sprite CharacterImage;

    void Awake()
    {
        foreach (Transform indicator in this.gameObject.transform)
        {
            indicator.GetComponent<Renderer>().enabled = false;
        }
    }

    // Mouse exits the character
    void OnMouseExit()
    {
        var indicator = this.gameObject.transform.GetChild(0).GetComponent<Renderer>();
        indicator.enabled = false;
    }
}
