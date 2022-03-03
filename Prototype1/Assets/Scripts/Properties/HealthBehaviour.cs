using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    public double MaximumHitPoints;
    public double Shield;

    public double HitPoints;

    public double Poison;
    public int PoisonTurnsRemaining;

    public bool Mirror;
    public int MirrorTurnsRemaining;

    public HealthBar healthBar;
    public HealthBar shieldBar;

    void Start()
    {
        HitPoints = MaximumHitPoints;
        healthBar.SetMaxHealth(MaximumHitPoints);

        shieldBar.SetMaxHealth(MaximumHitPoints);
        shieldBar.SetHealth(Shield);
    }

    public void Damage(double damage)
    {
        // Shield absorbs the damage first, when worn out, the remaining damage is dealt to the character
        if (Shield > 0)
        {
            Shield -= damage;
            if (Shield < 0)
            {
                HitPoints -= Math.Abs(Shield);
                Shield = 0;
            }
        }
        else
        {
            HitPoints -= damage;
        }

        healthBar.SetHealth(HitPoints);
        shieldBar.SetHealth(Shield);

        if (HitPoints <= 0)
        {
            // Die
            this.gameObject.GetComponent<Renderer>().enabled = false;

            //Debug.Log("DEAD");
        }
    }

    public void Heal(double heal)
    {
        HitPoints += heal;

        if (HitPoints > MaximumHitPoints)
        {
            HitPoints = MaximumHitPoints;
        }

        healthBar.SetHealth(HitPoints);
    }

    public void Protect(double protect)
    {
        Shield += protect;
        shieldBar.SetHealth(Shield);
    }

    public void PoisonDamage()
    {
        if (Poison > 0 && PoisonTurnsRemaining > 0)
        {
            Damage(Poison);
            PoisonTurnsRemaining--;

            if (PoisonTurnsRemaining == 0)
            {
                Poison = 0;
            }
        }
    }
}
