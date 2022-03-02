using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public string NextScene;

    public void SwitchTo(IList<Card> deck)
    {
        SceneSwitcher.SwitchTo(NextScene, deck);
    }
}
