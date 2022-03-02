using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peasant : Enemy
{
    public AudioClip ForkPierceSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        // Attack
        enemyMoves.Add(new EnemyMove
        {
            Attack = 8,
            Shield = 0,
            Heal = 0,
            Name = "Fork pierce",
            SoundEffect = ForkPierceSoundEffect,
        });
    }
}
