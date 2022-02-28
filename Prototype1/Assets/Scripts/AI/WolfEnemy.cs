using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        // Attack
        enemyMoves.Add(new EnemyMove
        {
            Attack = 5,
            Shield = 0,
            Heal = 0,
        });

        // Protect
        enemyMoves.Add(new EnemyMove
        {
            Attack = 0,
            Shield = 5,
            Heal = 0,
        });
    }
}
