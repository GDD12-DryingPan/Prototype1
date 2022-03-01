using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCell
{
    GameObject occupier;
    GameObject cellSquare;

    public GameCell(GameObject cellObject) {
        this.cellSquare = cellObject;
    }
}
