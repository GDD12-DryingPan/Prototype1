using System.Linq;
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
        this.grid = new GameCell[x, y];
        transformationMatrix = new float3x3(1f, -1f, 0f, 1f, 1f, 0f, 0f, 0f, 0f) * scale;
        inverseTransformationMatrix = (new float3x3(1f, 1f, 0f, -1f, 1f, 0f, 0f, 0f, 0f) / 2) / scale;
        for (int i = 0; i < x; i++) {
            for (int j = 0; j < y; j++) {
                Vector3 position = math.mul(transformationMatrix, new Vector3(i, j));
                position += origin;
                GameObject cell = GameObject.Instantiate(cellPrefab, position, Quaternion.identity);
                this.grid[i, j] = new GameCell(cell);
            }
        }
    }

    public GameCell getCellAtPosition(Vector3 position) {
        position -= origin;
        position = math.mul(inverseTransformationMatrix, position);
        int x = Mathf.RoundToInt(position.x);
        int y = Mathf.RoundToInt(position.y);
        if (x < 0 || x > this.x || y < 0 || y > this.y) return null;
        return grid[x, y];
    }

    private int EstimateDistance((int x, int y) start, (int x, int y) end)
    {
        return System.Math.Abs(start.x - end.x) + System.Math.Abs(start.y - end.y);
    }

    private List<(int x, int y)> ReconstructPath(Dictionary<(int x, int y), (int x, int y)> cameFrom, (int x, int y) current)
    {
        List<(int x, int y)> path = new List<(int x, int y)>
        {
            current,
        };

        while (cameFrom.Keys.Contains(current))
        {
            cameFrom.TryGetValue(current, out current);
            path.Add(current);
        }

        return path;
    }


    public List<(int x, int y)> PathSearch((int x, int y) start, (int x, int y) end) {
        var open = new List<(int x, int y)>
        {
            start,
        };
        var cameFrom = new Dictionary<(int x, int y), (int x, int y)>();
        var GScores = new Dictionary<(int x, int y), int>();
        var FScores = new Dictionary<(int x, int y), int>();

        GScores.Add(start, 0);
        FScores.Add(start, EstimateDistance(start, end));

        while (open.Count() > 0)
        {
            (int x, int y) current = FScores.Where(c => open.Contains(c.Key)).OrderBy(c => c.Value).FirstOrDefault().Key;

            if (current == end)
            {
                return ReconstructPath(cameFrom, current);
            }

            open.Remove(current);


            var neighbouringCells = new List<(int x, int y)>();
            // TODO: Check if neighbouring cells are occupied
            if (current.x > 0)
            {
                neighbouringCells.Add((current.x - 1, current.y));
            }
            if (current.x < x - 1)
            {
                neighbouringCells.Add((current.x + 1, current.y));
            }
            if (current.y > 0)
            {
                neighbouringCells.Add((current.x, current.y - 1));
            }
            if (current.y < y - 1)
            {
                neighbouringCells.Add((current.x, current.y + 1));
            }

            foreach (var neighbour in neighbouringCells)
            {
                int tentativeGScore = 0;
                GScores.TryGetValue(current, out tentativeGScore);
                tentativeGScore += 1;

                int neighbourGScore = 0;
                GScores.TryGetValue(neighbour, out neighbourGScore);

                if (!GScores.ContainsKey(neighbour) || tentativeGScore < neighbourGScore)
                {
                    cameFrom.Remove(neighbour);
                    cameFrom.Add(neighbour, current);

                    GScores.Remove(neighbour);
                    GScores.Add(neighbour, tentativeGScore);

                    FScores.Remove(neighbour);
                    FScores.Add(neighbour, tentativeGScore + EstimateDistance(neighbour, end));

                    if (!open.Contains(neighbour))
                    {
                        open.Add(neighbour);
                    }
                }
            }
        }

        return null;
    }
}
