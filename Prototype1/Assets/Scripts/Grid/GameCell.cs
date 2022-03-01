using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCell
{
    public GameObject occupier;
    public GameObject cellSquare;

    public GameCell(GameObject cellObject) {
        this.cellSquare = cellObject;
    }
}
