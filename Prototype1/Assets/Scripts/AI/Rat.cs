using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Enemy
{
    public AudioClip BiteSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        // Attack
        enemyMoves.Add(new EnemyMove
        {
            Attack = 5,
            Poison = 1,
            Name = "Poisonous Bite",
            SoundEffect = BiteSoundEffect,
        });
    }
}
