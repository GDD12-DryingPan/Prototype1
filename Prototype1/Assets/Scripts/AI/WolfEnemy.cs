using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfEnemy : Enemy
{
    //private IList<EnemyMove> enemyMoves = new List<EnemyMove>();

    // Start is called before the first frame update
    void Start()
    {
        // Basic attack
        enemyMoves.Add(new EnemyMove
        {
            Attack = 5,
            Shield = 0,
            Heal = 0,
        });

        // Powerful attack
        enemyMoves.Add(new EnemyMove
        {
            Attack = 10,
            Shield = 0,
            Heal = 0,
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
