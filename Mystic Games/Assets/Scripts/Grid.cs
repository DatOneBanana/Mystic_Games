using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {
    private int width;
    private int height;
    private int[,] gridArray;
    private float cellSize;

    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        gridArray = new int[width, height];
        this.cellSize = cellSize;
        Vector3 cellCenter = new Vector3(cellSize, cellSize) * 0.5f;

        for (int i = 0; i < gridArray.GetLength(0); i++) {
            for (int j = 0; j < gridArray.GetLength(1); j++) {
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i + 1, j), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y) * cellSize;
    }

    private void GetXY(Vector3 worldPos, out int x, out int y) {
        x = Mathf.FloorToInt(worldPos.x / cellSize);
        y = Mathf.FloorToInt(worldPos.y / cellSize);
    }

    public void SetValue(int x, int y, int value) {
        if(x >= 0 && y >= 0 && x < width && y < height) {
            gridArray[x, y] = value;
        }
        
    }

    public void SetValue(Vector3 worldPos, int value) {
        int x, y;
        GetXY(worldPos, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y) {
        if (x >= 0 && y >= 0 && x < width && y < height) {
            return gridArray[x, y];
        }
        else {
            return 0;
        }
    }
}
