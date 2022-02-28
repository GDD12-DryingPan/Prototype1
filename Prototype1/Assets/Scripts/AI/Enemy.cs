using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected IList<EnemyMove> enemyMoves = new List<EnemyMove>();

    private System.Random random = new System.Random();

    public void ExecuteMove(Character character)
    {
        int i = random.Next(enemyMoves.Count());
        EnemyMove enemyMove = enemyMoves.ElementAt(i);

        while ((enemyMove.Attack > 0 && character.IsEnemy) || (enemyMove.Attack == 0 && !character.IsEnemy))
        {
            i = random.Next(enemyMoves.Count());
            enemyMove = enemyMoves.ElementAt(i);
        }

        if (enemyMove.Attack > 0)
        {
            Debug.Log("Attack");

            var indicator = character.gameObject.transform.GetChild(1).GetComponent<Renderer>();
            indicator.enabled = true;
        }
        else
        {
            Debug.Log("Protect");

            var indicator = character.gameObject.transform.GetChild(0).GetComponent<Renderer>();
            indicator.enabled = true;
        }
    }
}
