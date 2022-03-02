using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip AttackSoundEffect;
    public AudioClip DefendSoundEffect;

    protected IList<EnemyMove> enemyMoves = new List<EnemyMove>();

    private System.Random random = new System.Random();

    public void ExecuteMove(Character character, Turns turns)
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
            character.gameObject.GetComponent<HealthBehaviour>().Damage(enemyMove.Attack);

            var indicator = character.gameObject.transform.GetChild(1).GetComponent<Renderer>();
            indicator.enabled = true;
        }
        else
        {
            character.gameObject.GetComponent<HealthBehaviour>().Protect(enemyMove.Shield);

            var indicator = character.gameObject.transform.GetChild(0).GetComponent<Renderer>();
            indicator.enabled = true;
        }

        turns.UpdateMove(enemyMove.Name);
        PlaySoundEffect(enemyMove.SoundEffect);
    }

    // Play sound effect
    private void PlaySoundEffect(AudioClip audio)
    {
        AudioSource.PlayClipAtPoint(audio, Vector2.zero, 1f);
    }
}
