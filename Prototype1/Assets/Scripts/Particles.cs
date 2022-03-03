using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public static Particles Instance;

    public ParticleSystem AttackEffect;
    public ParticleSystem FireballEffect;
    public ParticleSystem HealEffect;
    public ParticleSystem PoisonEffect;
    public ParticleSystem ShieldEffect;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }

        Instance = this;
    }

    public void Attack(Vector3 position)
    {
        Instantiate(AttackEffect, position);
    }

    public void Fireball(Vector3 position)
    {
        Instantiate(FireballEffect, position);
    }

    public void Heal(Vector3 position)
    {
        Instantiate(HealEffect, position);
    }

    public void Poison(Vector3 position)
    {
        Instantiate(PoisonEffect, position);
    }

    public void Shield(Vector3 position)
    {
        Instantiate(ShieldEffect, position);
    }

    private ParticleSystem Instantiate(ParticleSystem prefab, Vector3 position)
    {
        position.z = -1;

        ParticleSystem newParticleSystem = Instantiate(prefab, position, Quaternion.identity);
        Destroy(newParticleSystem.gameObject, newParticleSystem.main.startLifetime.constant);

        return newParticleSystem;
    }
}
