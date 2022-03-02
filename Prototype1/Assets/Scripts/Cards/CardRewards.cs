using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRewards : MonoBehaviour
{
    public List<Card> CommonCards;
    public List<Card> RareCards;

    private System.Random random = new System.Random();

    public Card GetRandomReward(double chanceOfRare)
    {
        double commonOrRare = random.NextDouble();
        if (commonOrRare < chanceOfRare)
        {
            // Rare
            int cardIndex = random.Next(RareCards.Count());
            return RareCards.ElementAt(cardIndex);
        }
        else
        {
            // Common
            int cardIndex = random.Next(CommonCards.Count());
            return CommonCards.ElementAt(cardIndex);
        }
    }
}
