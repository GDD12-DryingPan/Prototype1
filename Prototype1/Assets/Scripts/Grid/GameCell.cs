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

    public Vector3 getCenter() {
        Renderer renderer = this.cellSquare.GetComponent<Renderer>();
        return renderer.bounds.center;
    }

    public void placeOccupant(GameObject occupant) {
        if (this.occupier != null) deleteOccupant();
        this.occupier = occupant;
        occupant.transform.position = this.getCenter();
    }

    public void deleteOccupant() {
        GameObject.Destroy(occupier);
        this.occupier = null;
    }
}
