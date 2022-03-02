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
            Attack = 10,
            Name = "Pirate slash",
            SoundEffect = PirateSlashSoundEffect,
        });

        // Protect
        enemyMoves.Add(new EnemyMove
        {
            ApplyToEnemy = false,
            Shield = 10,
            Name = "Black shield",
            SoundEffect = BlackShieldSoundEffect,
        });
    }
}
