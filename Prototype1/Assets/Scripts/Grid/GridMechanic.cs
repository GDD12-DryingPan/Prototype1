using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMechanic : MonoBehaviour
{
    public GameObject gameObject;
    public int fieldNumber;
    public char fieldCharacter;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = gameObject.GetComponent<SpriteRenderer>();
        render.sortingOrder = 50;
        Instantiate(gameObject, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void onTriggerEnter2D(Collider2D c)
    {

    }
}
