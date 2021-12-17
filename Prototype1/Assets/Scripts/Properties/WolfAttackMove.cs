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
    void OnTriggerEnter(Collider c)
    {
        // for now it only works for the old man and not any other game object that has a character relation
        GameObject g = c.gameObject;

        HealthBehaviour h = g.GetComponent<HealthBehaviour>();

        if (Input.GetMouseButtonDown(0))
        {
            h.HitPoints -= (attackValue.Attack - h.Shield);
        }

        // character properties will be deleted
        // fix later
        

    }
}
