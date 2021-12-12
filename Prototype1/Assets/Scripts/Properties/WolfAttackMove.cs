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
        // for now it only works for the old man and not any other game object that has a character relation
        GameObject g = c.gameObject;

        OldMan oldMan = g.transform.parent.gameObject.GetComponent<OldMan>();
        GameObject properties = oldMan.characterProperties;
        HealthBehaviour health = properties.GetComponent<HealthBehaviour>();
        // for now this will do, but there needs to be an empty gameobject that controlls the whole flow of everything
        // there will be a script attached to it, but this one will be accessed through a flag
        // so there will be only one instance of the round manager gameobject and by accessing the script you can get vital 
        // information on the state of the round, like attack phase1 or 2 and move phase 1 or 2, or we will have it play out all at once and then repeat
        // still no clear approach, but yeah, there needs to be a central script where all the gameobjects can access game data about the phase 1 round is in.
        health.HitPoints = health.HitPoints - attackValue.Attack;

    }
}
