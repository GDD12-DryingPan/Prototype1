using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool ApplyToEnemy = true;

    // Debuffs
    public int Attack = 0;
    public int AdditionalAttack = 0;

    // Buffs
    public int Shield = 0;
    public int Heal = 0;
    public bool Berserk = false;

    // Sound effect
    public AudioClip SoundEffect;

    public string Name;
}
