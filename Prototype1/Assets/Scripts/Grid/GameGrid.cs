using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class GameGrid
{
    private GameCell[,] grid;
    private readonly int x;
    private readonly int y;

    Vector3 origin;
    float3x3 transformationMatrix;
    float3x3 inverseTransformationMatrix;
    public GameGrid(int x, int y, Vector3 origin, float scale, GameObject cellPrefab) {
        this.x = x;
        this.y = y;
        this.origin = origin;
        this.grid = new GameCell[x,y];
        transformationMatrix = new float3x3(1f, -1f, 0f, 1f, 1f, 0f, 0f, 0f, 0f) * scale;
        inverseTransformationMatrix = (new float3x3(1f, 1f, 0f, -1f, 1f, 0f, 0f, 0f, 0f) / 2) / scale;
        for (int i = 0; i < x; i++) {
            for (int j = 0; j < y; j++) {
                Vector3 position = math.mul(transformationMatrix, new Vector3(i,j));
                position += origin;
                GameObject cell = GameObject.Instantiate(cellPrefab, position, Quaternion.identity);
                this.grid[i,j] = new GameCell(cell);
            }
        }
    }

    public GameCell getCellAtPosition(Vector3 position) {
        position -= origin;
        position = math.mul(inverseTransformationMatrix, position);
        int x = Mathf.RoundToInt(position.x);
        int y = Mathf.RoundToInt(position.y);
        if (x < 0 || x > this.x || y < 0 || y > this.y) return null;
        return grid[x,y];
    }
}
