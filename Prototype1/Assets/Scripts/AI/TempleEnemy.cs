using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleEnemy : Enemy
{
    public AudioClip BlobSoundEffect;
    public AudioClip ShieldSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        // Attack
        enemyMoves.Add(new EnemyMove
        {
            Attack = 14,
            Name = "Acidic Spit",
            SoundEffect = BlobSoundEffect,
        });

        enemyMoves.Add(new EnemyMove
        {
            ApplyToEnemy = false,
            Shield = 14,
            Name = "Dark Shield",
            SoundEffect = ShieldSoundEffect,
        });
    }
}
