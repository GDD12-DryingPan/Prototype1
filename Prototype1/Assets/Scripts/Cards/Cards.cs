using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    private IList<Card> DrawPile = new List<Card>();
    private IList<Card> Hand = new List<Card>();
    private IList<Card> DiscardPile = new List<Card>();

    // Add cards from deck to the draw pile and shuffle it
    public void Initialize(IList<Card> cards)
    {
        foreach (Card card in cards)
        {
            DrawPile.Add(card);
        }

        var random = new System.Random();
        DrawPile = DrawPile.OrderBy(x => random.Next()).ToList();
    }

    // Draw cards from draw pile
    public void DrawCards(int numberOfCards)
    {
        int cardsLeft = numberOfCards;

        for (int i = 0; i < System.Math.Min(DrawPile.Count(), numberOfCards); i++)
        {
            Hand.Add(DrawPile.ElementAt(i));
            DrawPile.RemoveAt(i);
        }

        // If we still have cards to draw
        if (cardsLeft > 0)
        {
            // Shuffle discard pile into draw pile
            for (int i = 0; i < DiscardPile.Count(); i++)
            {
                DrawPile.Add(DiscardPile.ElementAt(i));
                DiscardPile.RemoveAt(i);
            }

            var random = new System.Random();
            DrawPile = DrawPile.OrderBy(x => random.Next()).ToList();
        }

        // Draw the remaining number of cards
        for (int i = 0; i < System.Math.Min(DrawPile.Count(), cardsLeft); i++)
        {
            Hand.Add(DrawPile.ElementAt(i));
            DrawPile.RemoveAt(i);
        }
    }

    // Play a card in hand
    public void PlayCard(int i, GameObject target)
    {
        // TODO: Add card effect
        if (this.gameObject.GetComponent<AttackScript>() != null)
        {
            this.gameObject.GetComponent<AttackScript>().attackAction(target);
        }
        if (this.gameObject.GetComponent<HealScript>() != null)
        {
            this.gameObject.GetComponent<HealScript>().healAction(target);
        }
        if (this.gameObject.GetComponent<ShieldScript>() != null)
        {
            this.gameObject.GetComponent<ShieldScript>().shieldAction(target);
        }

        DiscardPile.Add(Hand.ElementAt(i));
        Hand.RemoveAt(i);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
