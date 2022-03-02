using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected IList<EnemyMove> enemyMoves = new List<EnemyMove>();

    private System.Random random = new System.Random();

    public void ExecuteMove(IList<Character> characters, Turns turns)
    {
        int i = random.Next(enemyMoves.Count());
        EnemyMove enemyMove = enemyMoves.ElementAt(i);

        if (enemyMove.ApplyToEnemy)
        {
            // Debuff to "enemy", i.e. our character
            Character character = characters.Where(x => !x.IsEnemy).FirstOrDefault();
            var indicator = character.gameObject.transform.GetChild(1).GetComponent<Renderer>();
            indicator.enabled = true;

            HealthBehaviour healthBehaviour = character.gameObject.GetComponent<HealthBehaviour>();

            if (enemyMove.Attack > 0)
            {
                healthBehaviour.Damage(enemyMove.Attack + enemyMove.AdditionalAttack);
            }
            if (enemyMove.Poison > 0)
            {
                // Poison is applied for the following three turns by default
                healthBehaviour.Poison = enemyMove.Poison;
                healthBehaviour.PoisonTurnsRemaining += 3;
            }
        }
        else
        {
            // Buff to a random enemy
            Character character = characters.Where(x => x.IsEnemy).OrderBy(x => random.Next()).FirstOrDefault();
            var indicator = character.gameObject.transform.GetChild(0).GetComponent<Renderer>();
            indicator.enabled = true;

            HealthBehaviour healthBehaviour = character.gameObject.GetComponent<HealthBehaviour>();

            if (enemyMove.Shield > 0)
            {
                healthBehaviour.Protect(enemyMove.Shield);
            }
            if (enemyMove.Heal > 0)
            {
                healthBehaviour.Heal(enemyMove.Heal);
            }
            if (enemyMove.Berserk)
            {
                foreach (EnemyMove move in enemyMoves)
                {
                    move.AdditionalAttack = move.Attack;
                }
            }
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
