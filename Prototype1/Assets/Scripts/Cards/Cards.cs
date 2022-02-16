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

    // Draw cards from draw pile
    public void DrawCards(int numberOfCards)
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
        // TODO: Add card effect (attack, protect, heal ...)

        DiscardPile.Add(Hand.ElementAt(i));
        Hand.RemoveAt(i);

        // TODO: Incorporate into turn-based combat
        // At the moment we discard the hand and end turn as soon as any card is played
        DiscardHand();
    }

    // Discard hand at the end of the turn
    public void DiscardHand()
    {
        foreach (Card card in Hand)
        {
            DiscardPile.Add(card);
        }
        Hand.Clear();

        // Draw cards after discarding
        DrawCards(3);
    }
}
