using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy
{
    public AudioClip ClawingSoundEffect;

    // Start is called before the first frame update
    void Start()
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
