using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peasant : Enemy
{
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
            SoundEffect = AttackSoundEffect,
        });

        // Protect
        enemyMoves.Add(new EnemyMove
        {
            Attack = 0,
            Shield = 5,
            Heal = 0,
            Name = "Villager's shield",
            SoundEffect = DefendSoundEffect,
        });
    }
}
