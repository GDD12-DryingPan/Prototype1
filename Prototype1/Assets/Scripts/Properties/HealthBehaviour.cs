using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{

    public double HitPoints;
    public double MaximumHitPoints;
    public double Shield;

    void Start()
    {
        HitPoints = 100;
    }

    void Update()
    {
        MaximumHitPoints = HitPoints;
    }

    public void Damage(double damage)
    {
    /* The shield will absorb the damage first, and then will pass
     the damage left to the health */
        if (Shield <= 0)
        {
            HitPoints -= damage;

            if (HitPoints <= 0)
            {
                // Die
            }
        }
        else
        {
            Shield -= damage;
            if(Shield < 0)
            {
                HitPoints -= Shield;
                Shield = 0;
            }
        }
        
    }

    public void Heal(double heal)
    {
        HitPoints += heal;

        if (HitPoints > MaximumHitPoints)
        {
            HitPoints = MaximumHitPoints;
        }
    }

    public void addShield(double newShield)
    {
        Shield += newShield;
    }

    public void generateHitPoints(double progression)
    {

    }
}
