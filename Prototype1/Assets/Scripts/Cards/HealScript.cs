using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour
{
    public double healValue = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void healAction(GameObject gObject)
    {
        gObject.GetComponent<HealthBehaviour>().Heal(healValue);
    }
}
