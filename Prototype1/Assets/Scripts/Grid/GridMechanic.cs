using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridMechanic : MonoBehaviour
{
    public GameObject cellPrefab;
    public GameObject placer;
    public int x;
    public int y;
    public float scale;
    public Vector3 origin;
    private GameGrid grid;
    void Start() {
        this.grid = new GameGrid(x, y, origin, scale, cellPrefab);

        
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            grid.getCellAtPosition(UtilsClass.GetMouseWorldPosition()).placeOccupant(GameObject.Instantiate(placer));
        }
    }
}
