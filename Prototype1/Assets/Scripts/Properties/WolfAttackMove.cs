using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttackMove : MonoBehaviour
{
    private AttackBehaviour attackValue;
    // Start is called before the first frame update
    void Start()
    {
        // this is the way we will access all the attk, def, res, and character values! it works!!! 
        attackValue = transform.parent.gameObject.GetComponent<AttackBehaviour>();
        Debug.Log("Attack of Wolf: "+attackValue.Attack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this is for the colider box in front of the wolf
    void OnTriggerEnter2D(Collider2D c)
    {

    }
}
