using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMechanic : MonoBehaviour
{
    public GameObject gameObject1;
    public int fieldNumber;
    public char fieldCharacter;
    private SpriteRenderer render;

    void Awake()
    {
        Instantiate(gameObject1, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void onTriggerEnter2D(Collider2D c)
    {

    }
}
