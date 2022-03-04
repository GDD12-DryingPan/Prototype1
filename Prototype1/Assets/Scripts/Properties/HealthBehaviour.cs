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

    private bool FadeOut = true;

    void Awake()
    {
        //HitPoints = MaximumHitPoints;
        healthBar.SetMaxHealth(MaximumHitPoints);

        shieldBar.SetMaxHealth(MaximumHitPoints);
        shieldBar.SetHealth(Shield);
    }

    void Update()
    {
        if (HitPoints <= 0 && FadeOut)
        {
            Color color = this.GetComponent<Renderer>().material.color;
            float fade = color.a - Time.deltaTime;

            color = new Color(color.r, color.g, color.b, fade);
            this.GetComponent<Renderer>().material.color = color;

            if (color.a <= 0)
            {
                FadeOut = false;
            }
        }
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

        //if (HitPoints <= 0)
        //{
        //    // Die
        //    //this.gameObject.GetComponent<Renderer>().enabled = false;

        //    //Debug.Log("DEAD");
        //}
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
