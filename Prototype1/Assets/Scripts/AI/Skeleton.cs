using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public AudioClip PirateSlashSoundEffect;
    public AudioClip BlackShieldSoundEffect;

    void Awake()
    {
        // Attack
        enemyMoves.Add(new EnemyMove
        {
            ApplyToEnemy = true,
            Attack = 13,
            Name = "Pirate Slash",
            SoundEffect = PirateSlashSoundEffect,
        });

        // Protect
        enemyMoves.Add(new EnemyMove
        {
            ApplyToEnemy = false,
            Shield = 5,
            Name = "Black Shield",
            SoundEffect = BlackShieldSoundEffect,
        });
    }
}
