using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{

    public double HitPoints;
    public double MaximumHitPoints;

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
        HitPoints -= damage;

        if (HitPoints <= 0)
        {
            // Die
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

    public void generateHitPoints(double progression)
    {

    }
}
