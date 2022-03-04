using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy
{
    public AudioClip BiteSoundEffect;

    // Start is called before the first frame update
    void Start()
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
