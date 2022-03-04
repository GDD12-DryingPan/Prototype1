using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public AudioClip BlobSoundEffect;
    public AudioClip BerserkSoundEffect;
    public AudioClip HealSoundEffect;
    public AudioClip ShieldSoundEffect;

    void Awake()
    {
        // Attack
        enemyMoves.Add(new EnemyMove
        {
            Attack = 15,
            Poison = 3,
            Name = "Poisonous Spit",
            SoundEffect = BlobSoundEffect,
        });

        enemyMoves.Add(new EnemyMove
        {
            ApplyToEnemy = false,
            Berserk = true,
            Name = "Battle March",
            SoundEffect = BerserkSoundEffect,
        });

        enemyMoves.Add(new EnemyMove
        {
            ApplyToEnemy = false,
            Heal = 10,
            Name = "Dark Renewal",
            SoundEffect = HealSoundEffect,
        });

        enemyMoves.Add(new EnemyMove
        {
            ApplyToEnemy = false,
            Shield = 15,
            Mirror = true,
            Name = "Dark Mirror",
            SoundEffect = ShieldSoundEffect,
        });
    }
}
