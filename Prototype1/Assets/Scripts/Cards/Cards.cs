using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cards : MonoBehaviour
{
    public List<GameObject> CardButtons;
    public List<Card> InitialDeck;

    private IList<Card> Deck = new List<Card>();

    private IList<Card> DrawPile = new List<Card>();
    private IList<Card> Hand = new List<Card>();
    private IList<Card> DiscardPile = new List<Card>();

    private bool IsCardBeingPlayed = false;
    private int CardBeingPlayedIndex;

    void Start()
    {
        if (Deck.Count() == 0)
        {
            foreach (Card card in InitialDeck)
            {
                Deck.Add(card);
            }
        }

        // Add cards to the draw pile
        foreach (Card card in Deck)
        {
            DrawPile.Add(card);
        }

        // Shuffle the deck
        var random = new System.Random();
        DrawPile = DrawPile.OrderBy(x => random.Next()).ToList();

        // Draw the cards
        DrawCards(3);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsCardBeingPlayed)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                Debug.Log(hit.collider);

                if (hit.collider != null)
                {
                    Card CardBeingPlayed = Hand.ElementAt(CardBeingPlayedIndex);
                    Character character = hit.collider.gameObject.GetComponent<Character>();
                    if (character != null)
                    {
                        if (ValidMove(CardBeingPlayed, character))
                        {
                            // TODO: Apply card action to the selected character
                            if (CardBeingPlayed.ApplyToEnemy)
                            {
                                // Debuff to enemy
                            }
                            else
                            {
                                // Buff to character
                            }

                            // Remove card from hand
                            DiscardPile.Add(Hand.ElementAt(CardBeingPlayedIndex));
                            Hand.RemoveAt(CardBeingPlayedIndex);

                            IsCardBeingPlayed = false;

                            // TODO: Incorporate into turn-based combat
                            // At the moment we discard the hand and end turn as soon as any card is played
                            DiscardHand();
                        }
                    }
                }
            }
        }
    }

    // Draw cards from draw pile
    private void DrawCards(int numberOfCards)
    {
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

            var random = new System.Random();
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

        // Show cards in hand
        for (int i = 0; i < Hand.Count(); i++)
        {
            Button cardPrefabButton = Hand.ElementAt(i).gameObject.GetComponent<Button>();

            Button cardButton = CardButtons.ElementAt(i).GetComponent<Button>();
            cardButton.image.sprite = cardPrefabButton.image.sprite;
        }
    }

    // Play a card in hand
    public void PlayCard(int i)
    {
        IsCardBeingPlayed = true;
        CardBeingPlayedIndex = i;
    }

    // Discard hand at the end of the turn
    private void DiscardHand()
    {
        foreach (Card card in Hand)
        {
            DiscardPile.Add(card);
        }
        Hand.Clear();

        // Draw cards after discarding
        DrawCards(3);
    }

    private bool ValidMove(Card card, Character character)
    {
        return (card.ApplyToEnemy && character.IsEnemy) || (!card.ApplyToEnemy && !character.IsEnemy);
    }
}