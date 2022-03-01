using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turns : MonoBehaviour
{
    public Image CharacterImage;
    public Text MoveText;

    private IList<Character> Characters;
    private int i = 0;
    private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        Characters = FindObjectsOfType<Character>();
        NextTurn();
    }

    public void NextTurn()
    {
        // Disable indicators for previous character
        MoveText.text = string.Empty;

        foreach (Character character in Characters)
        {
            foreach (Transform indicator in character.gameObject.transform)
            {
                indicator.GetComponent<Renderer>().enabled = false;
            }
        }

        // Reset the list of characters
        int numberOfEnemies = 0;
        int numberOfPlayers = 0;

        var characters = FindObjectsOfType<Character>();
        Characters = new List<Character>();
        foreach (Character character in characters)
        {
            Debug.Log($"{character} {character.gameObject.GetComponent<HealthBehaviour>().HitPoints}");

            if (character.gameObject.GetComponent<Renderer>().enabled)
            {
                Characters.Add(character);

                if (character.IsEnemy)
                {
                    numberOfEnemies++;
                }
                else
                {
                    numberOfPlayers++;
                }
            }
            else
            {
                Destroy(character.gameObject);
            }
        }
        Debug.Log("");

        // Reset turns
        if (i >= Characters.Count())
        {
            i = 0;
        }

        Character characterOnTurn = Characters.ElementAt(i);
        CharacterImage.sprite = characterOnTurn.CharacterImage;

        if (!characterOnTurn.IsEnemy)
        {
            // Our character, enable cards and moving
            Cards cards = characterOnTurn.gameObject.GetComponent<Cards>();
            cards.DrawCards(3, this);

            i++;
        }
        else
        {
            // Enemy, pick a random character and a random available move
            var indicator = characterOnTurn.gameObject.transform.GetChild(0).GetComponent<Renderer>();
            indicator.enabled = true;

            int characterIndex = random.Next(Characters.Count());
            Character character = Characters.ElementAt(characterIndex);

            Enemy enemy = characterOnTurn.gameObject.GetComponent<Enemy>();
            enemy.ExecuteMove(character, this);

            i++;
            Invoke("NextTurn", 3);
        }
    }

    public void DelayNextTurn()
    {
        // Poison damage is applied after our character is on turn
        foreach (Character character in Characters)
        {
            var healthBehaviour = character.gameObject.GetComponent<HealthBehaviour>();
            healthBehaviour.PoisonDamage();
        }

        Invoke("NextTurn", 3);
    }

    public void UpdateMove(string move)
    {
        MoveText.text = move;
    }
}
