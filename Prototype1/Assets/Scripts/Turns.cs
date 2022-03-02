using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turns : MonoBehaviour
{
    public Image CharacterImage;
    public Text MoveText;

    public Text CardTitleText;
    public Text CardDescriptionText;

    public Canvas VictoryCanvas;
    public Text CardRewardText;

    public Canvas DefeatCanvas;

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

        // If our character or all enemies are dead, no further actions can be taken
        if (numberOfPlayers == 0)
        {
            // Defeat
            DefeatCanvas.gameObject.SetActive(true);
            return;
        }
        else if (numberOfEnemies == 0)
        {
            // Card reward
            CardRewards cardRewards = this.gameObject.GetComponent<CardRewards>();
            Card card = cardRewards.GetRandomReward(0.2);

            Character character = Characters.FirstOrDefault();
            Cards characterCards = character.gameObject.GetComponent<Cards>();

            characterCards.AddToDeck(card);
            CardRewardText.text = string.Format($"{card.Name}\n{card.Description}");

            VictoryCanvas.gameObject.SetActive(true);
            return;
        }

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

    public void UpdateCardSelected(Card card)
    {
        CardTitleText.text = card.Name;
        CardDescriptionText.text = card.Description;
    }

    public void UpdateMove(string move)
    {
        MoveText.text = move;

        CardTitleText.text = string.Empty;
        CardDescriptionText.text = string.Empty;
    }
}
