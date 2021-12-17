using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public double ShieldValue = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shieldAction(GameObject gObject)
    {
        gObject.GetComponent<HealthBehaviour>().addShield(ShieldValue);
    }
}
