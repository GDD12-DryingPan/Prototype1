using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour
{
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
        // Disable actions for previous character
        foreach (Character character in Characters)
        {
            foreach (Transform indicator in character.gameObject.transform)
            {
                indicator.GetComponent<Renderer>().enabled = false;
            }
        }

        // Reset turns
        if (i >= Characters.Count())
        {
            i = 0;
        }

        Character characterOnTurn = Characters.ElementAt(i);

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
            enemy.ExecuteMove(character);

            i++;
            Invoke("NextTurn", 3);
        }
    }
}
