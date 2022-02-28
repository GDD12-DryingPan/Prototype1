using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour
{
    private IList<Character> characters;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        characters = FindObjectsOfType<Character>();
        NextTurn();
    }

    public void NextTurn()
    {
        // Disable actions for previous character

        if (i >= characters.Count())
        {
            i = 0;
        }

        Character characterOnTurn = characters.ElementAt(i);
        Debug.Log(characterOnTurn);

        if (!characterOnTurn.IsEnemy)
        {
            // Our character, enable cards and moving
            Cards cards = characterOnTurn.gameObject.GetComponent<Cards>();
            cards.DrawCards(3, this);

            i++;
        }
        else
        {
            // Enemy, pick a random available move
            Enemy enemy = characterOnTurn.gameObject.GetComponent<Enemy>();
            enemy.ExecuteMove();

            i++;
            NextTurn();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
