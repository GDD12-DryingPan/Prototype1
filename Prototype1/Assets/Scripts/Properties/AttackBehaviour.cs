using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{
    public double Attack;
    // Start is called before the first frame update
    void Start()
    {
        // just to give it a base value if nothing has changed.
        Attack = 40;
    }

    // Update is called once per frame
    void Update()
    {
        // load either script values from gameobject refferences through flags
    }

    public void generateAttack(double progression)
    {

    }
}
