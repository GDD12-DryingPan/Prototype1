using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public AudioClip PirateSlashSoundEffect;
    public AudioClip BlackShieldSoundEffect;

    // Start is called before the first frame update
    void Start()
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
            Shield = 10,
            Name = "Black Shield",
            SoundEffect = BlackShieldSoundEffect,
        });
    }
}
