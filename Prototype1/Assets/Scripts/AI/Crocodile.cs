using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy
{
    public AudioClip BiteSoundEffect;

    void Awake()
    {
        // Attack
        enemyMoves.Add(new EnemyMove
        {
            Attack = 8,
            Name = "Terrible Bite",
            SoundEffect = BiteSoundEffect,
        });
    }
}
