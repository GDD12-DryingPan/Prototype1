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
        //while (enemyMoves != null && !enemyMoves.Any())
        //{
        //    continue;
        //}

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

                //Particles.Instance.Attack(character.gameObject.transform.position);

                if (healthBehaviour.Mirror)
                {
                    HealthBehaviour characterHealthBehaviour = this.gameObject.GetComponent<HealthBehaviour>();
                    characterHealthBehaviour.Damage(enemyMove.Attack + enemyMove.AdditionalAttack);

                    //Particles.Instance.Attack(this.gameObject.transform.position);
                }
            }
            if (enemyMove.Poison > 0)
            {
                // Poison is applied for the following three turns by default
                healthBehaviour.Poison = enemyMove.Poison;
                healthBehaviour.PoisonTurnsRemaining += 3;

                //Particles.Instance.Poison(character.gameObject.transform.position);
            }

            // Animate attacking character
            var animation = gameObject.GetComponent<Animation>();
            animation.Play();
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

                //Particles.Instance.Shield(character.gameObject.transform.position);
            }
            if (enemyMove.Heal > 0)
            {
                healthBehaviour.Heal(enemyMove.Heal);

                //Particles.Instance.Heal(character.gameObject.transform.position);
            }
            if (enemyMove.Berserk)
            {
                foreach (EnemyMove move in enemyMoves)
                {
                    move.AdditionalAttack = move.Attack;
                }
            }
            if (enemyMove.Mirror)
            {
                healthBehaviour.Mirror = true;
                healthBehaviour.MirrorTurnsRemaining = 3;

                //Particles.Instance.Shield(character.gameObject.transform.position);
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
