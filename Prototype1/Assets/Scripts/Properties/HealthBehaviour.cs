using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    public double MaximumHitPoints = 100;

    private double HitPoints;

    void Awake()
    {
        HitPoints = MaximumHitPoints;
    }

    void Start()
    {

    }

    void Update()
    {

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
}
