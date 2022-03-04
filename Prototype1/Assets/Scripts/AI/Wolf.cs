using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy
{
    public AudioClip ClawingSoundEffect;

    void Awake()
    {
        // Attack
        enemyMoves.Add(new EnemyMove
        {
            Attack = 3,
            Name = "Clawing",
            SoundEffect = ClawingSoundEffect,
        });
    }
}
