using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneSwitcher
{
    public static IList<Card> Deck = new List<Card>();
    public static double HitPoints = 100;

    public static void SwitchTo(string scene, IList<Card> deck, double hitPoints)
    {
        Deck = deck;
        HitPoints = hitPoints;
        SceneManager.LoadScene(scene);
    }
}
