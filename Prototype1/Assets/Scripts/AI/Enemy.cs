using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected IList<EnemyMove> enemyMoves = new List<EnemyMove>();

    private System.Random random = new System.Random();

    public void ExecuteMove()
    {
        int i = random.Next(enemyMoves.Count);
        EnemyMove enemyMove = enemyMoves.ElementAt(i);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
