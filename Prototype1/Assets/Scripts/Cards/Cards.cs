using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cards : MonoBehaviour
{
    public List<Card> InitialDeck;

    private IList<GameObject> CardButtons;

    private IList<Card> Deck = new List<Card>();

    private IList<Card> DrawPile = new List<Card>();
    private IList<Card> Hand = new List<Card>();
    private IList<Card> DiscardPile = new List<Card>();

    private bool CanPlay = false;
    private bool IsCardBeingPlayed = false;
    private int CardBeingPlayedIndex;

    private Turns Turns;

    private System.Random random = new System.Random();

    private void Awake()
    {
        if (SceneSwitcher.Deck.Count() > 0)
        {
            Deck = SceneSwitcher.Deck;
        }
    }

    void Start()
    {
        // Get card buttons
        if (CardButtons == null)
        {
            CardButtons = GameObject.FindGameObjectsWithTag("Card");

            for (int i = 0; i < CardButtons.Count(); i++)
            {
                var cardButton = CardButtons.ElementAt(i).GetComponent<Button>();
                var index = CardButtons.ElementAt(i).GetComponent<CardButton>().i;

                cardButton.onClick.AddListener(delegate { PlayCard(index); });

                var color = cardButton.targetGraphic.color;
                color.a = 0;
                cardButton.targetGraphic.color = color;
            }
        }


        // Initialize the deck
        if (Deck.Count() == 0)
        {
            foreach (Card card in InitialDeck)
            {
                // Additional damage is reset if applied in the previous battle
                card.AdditionalAttack = 0;

                Deck.Add(card);
            }
        }

        // Add cards to the draw pile
        foreach (Card card in Deck)
        {
            DrawPile.Add(card);
        }

        // Shuffle the deck
        DrawPile = DrawPile.OrderBy(x => random.Next()).ToList();
    }

    void Update()
    {   
        if (IsCardBeingPlayed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                Card CardBeingPlayed = Hand.ElementAt(CardBeingPlayedIndex);
                Character character = hit.collider.gameObject.GetComponent<Character>();
                if (character != null)
                {
                    if (ValidMove(CardBeingPlayed, character))
                    {
                        var indicator = character.gameObject.transform.GetChild(0).GetComponent<Renderer>();
                        indicator.enabled = true;

                        // TODO: Apply card action to the selected character
                        if (Input.GetMouseButtonDown(0))
                        {
                            if (CardBeingPlayed.ApplyToEnemy)
                            {
                                // Debuff to enemy
                                HealthBehaviour healthBehaviour = character.gameObject.GetComponent<HealthBehaviour>();

                                if (CardBeingPlayed.Attack > 0)
                                {
                                    healthBehaviour.Damage(CardBeingPlayed.Attack + CardBeingPlayed.AdditionalAttack);

                                    // Optional: Show particles on card effect
                                    // Particles.Instance.Attack(character.gameObject.transform.position);

                                    if (healthBehaviour.Mirror)
                                    {
                                        HealthBehaviour characterHealthBehaviour = this.gameObject.GetComponent<HealthBehaviour>();
                                        characterHealthBehaviour.Damage(CardBeingPlayed.Attack + CardBeingPlayed.AdditionalAttack);
                                    }
                                }
                                if (CardBeingPlayed.Poison > 0)
                                {
                                    // Poison is applied for the following three turns by default
                                    healthBehaviour.Poison = CardBeingPlayed.Poison;
                                    healthBehaviour.PoisonTurnsRemaining += 3;
                                }
                            }
                            else
                            {
                                // Buff to character
                                HealthBehaviour healthBehaviour = character.gameObject.GetComponent<HealthBehaviour>();

                                if (CardBeingPlayed.Shield > 0)
                                {
                                    healthBehaviour.Protect(CardBeingPlayed.Shield);
                                }
                                if (CardBeingPlayed.Heal > 0)
                                {
                                    healthBehaviour.Heal(CardBeingPlayed.Heal);
                                }
                                if (CardBeingPlayed.Berserk)
                                {
                                    foreach (Card card in Deck)
                                    {
                                        card.AdditionalAttack = card.Attack;
                                    }
                                }
                                if (CardBeingPlayed.Mirror)
                                {
                                    healthBehaviour.Mirror = true;
                                    healthBehaviour.MirrorTurnsRemaining = 4;
                                }
                            }


                            // Card sound effect
                            PlaySoundEffect(CardBeingPlayed.SoundEffect);

                            // Card name
                            Turns.UpdateMove(CardBeingPlayed.Name);

                            // Remove card from hand
                            DiscardPile.Add(Hand.ElementAt(CardBeingPlayedIndex));
                            Hand.RemoveAt(CardBeingPlayedIndex);

                            GameObject cardButton = CardButtons.ElementAt(CardBeingPlayedIndex);
                            Vector3 position = cardButton.gameObject.transform.position;
                            position.y -= 0.25f;
                            cardButton.gameObject.transform.position = position;

                            IsCardBeingPlayed = false;

                            // When the hand is discarded, the turn ends
                            CanPlay = false;
                            DiscardHand();
                        }
                    }
                }
            }
        }
    }

    public void AddToDeck(Card card)
    {
        Deck.Add(card);
    }

    public IList<Card> GetDeck()
    {
        return Deck;
    }

    // Draw cards from draw pile
    public void DrawCards(int numberOfCards, Turns turns)
    {
        Turns = turns;

        int cardsLeft = numberOfCards;

        // Draw cards from draw pile
        IList<int> cardIndicesToRemove = new List<int>();
        for (int i = 0; i < System.Math.Min(DrawPile.Count(), numberOfCards); i++)
        {
            Hand.Add(DrawPile.ElementAt(i));
            cardIndicesToRemove.Add(i);

            cardsLeft--;
        }

        foreach (int i in cardIndicesToRemove)
        {
            DrawPile.RemoveAt(0);
        }

        // If we still have cards to draw
        if (cardsLeft > 0)
        {
            // Shuffle discard pile into draw pile
            for (int i = 0; i < DiscardPile.Count(); i++)
            {
                DrawPile.Add(DiscardPile.ElementAt(i));
            }
            DiscardPile.Clear();

            DrawPile = DrawPile.OrderBy(x => random.Next()).ToList();
        }

        // Draw the remaining number of cards
        cardIndicesToRemove.Clear();
        for (int i = 0; i < System.Math.Min(DrawPile.Count(), cardsLeft); i++)
        {
            Hand.Add(DrawPile.ElementAt(i));
            cardIndicesToRemove.Add(i);
        }

        foreach (int i in cardIndicesToRemove)
        {
            DrawPile.RemoveAt(0);
        }

        CanPlay = true;

        // Show cards in hand
        for (int i = 0; i < Hand.Count(); i++)
        {
            Button cardPrefabButton = Hand.ElementAt(i).gameObject.GetComponent<Button>();

            Button cardButton = CardButtons.ElementAt(i).GetComponent<Button>();
            cardButton.image.sprite = cardPrefabButton.image.sprite;

            var color = cardButton.targetGraphic.color;
            color.a = 100;
            cardButton.targetGraphic.color = color;
        }
    }

    // Play a card in hand
    public void PlayCard(int i)
    {
        if (CanPlay)
        {
            if (IsCardBeingPlayed)
            {
                GameObject cardButton = CardButtons.ElementAt(CardBeingPlayedIndex);
                Vector3 position = cardButton.gameObject.transform.position;
                position.y -= 0.25f;
                cardButton.gameObject.transform.position = position;

                IsCardBeingPlayed = false;
            }

            if (!IsCardBeingPlayed)
            {
                IsCardBeingPlayed = true;
                CardBeingPlayedIndex = i;

                GameObject cardButton = CardButtons.ElementAt(i);
                Vector3 position = cardButton.gameObject.transform.position;
                position.y += 0.25f;
                cardButton.gameObject.transform.position = position;

                Card cardBeingPlayed = Hand.ElementAt(CardBeingPlayedIndex);
                Turns.UpdateCardSelected(cardBeingPlayed);
            }
        }
    }

    // Discard hand at the end of the turn
    private void DiscardHand()
    {
        foreach (Card card in Hand)
        {
            DiscardPile.Add(card);
        }
        Hand.Clear();

        for (int i = 0; i < CardButtons.Count(); i++)
        {
            Button cardButton = CardButtons.ElementAt(i).GetComponent<Button>();

            var color = cardButton.targetGraphic.color;
            color.a = 0;
            cardButton.targetGraphic.color = color;
        }

        // End turn
        Turns.DelayNextTurn();
    }

    // Determine if the object selection is valid
    private bool ValidMove(Card card, Character character)
    {
        return (card.ApplyToEnemy && character.IsEnemy) || (!card.ApplyToEnemy && !character.IsEnemy);
    }

    // Play sound effect
    private void PlaySoundEffect(AudioClip audio)
    {
        AudioSource.PlayClipAtPoint(audio, Vector2.zero, 1f);
    }
}