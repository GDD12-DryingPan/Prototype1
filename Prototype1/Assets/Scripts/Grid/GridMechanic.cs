using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridMechanic : MonoBehaviour
{
    public GameObject cellPrefab;
    public int x;
    public int y;
    public float scale;
    public Vector3 origin;
    private GameGrid grid;
    void Start() {
        this.grid = new GameGrid(x, y, origin, scale, cellPrefab);

        // Path search algorithm
        var path = grid.PathSearch((1, 1), (4, 3));
        foreach(var cell in path)
        {
            Debug.Log(cell);
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log(grid.getCellAtPosition(UtilsClass.GetMouseWorldPosition()) == null);
        }
    }
}
