using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class GameGrid
{
    private GameCell[,] grid;

    Vector3 origin;
    float3x3 transformationMatrix;
    public GameGrid(int x, int y, Vector3 origin, float scale, GameObject cellPrefab) {
        this.origin = origin;
        this.grid = new GameCell[x,y];
        transformationMatrix = new float3x3(1f, -1f, 0f, 1f, 1f, 0f, 0f, 0f, 0f) * scale;
        for (int i = 0; i < x; i++) {
            for (int j = 0; j < y; j++) {
                Vector3 position = math.mul(transformationMatrix, new Vector3(i,j));
                position += origin;
                Debug.Log(position);
                GameObject cell = GameObject.Instantiate(cellPrefab, position, Quaternion.identity);
                this.grid[i,j] = new GameCell(cell);
            }
        }
    }
}
