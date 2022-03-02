using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneSwitcher
{
    public static IList<Card> Deck = new List<Card>();

    public static void SwitchTo(string scene, IList<Card> deck)
    {
        Deck = deck;
        SceneManager.LoadScene(scene);
    }
}
