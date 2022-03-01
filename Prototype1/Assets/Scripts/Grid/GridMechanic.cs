using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
