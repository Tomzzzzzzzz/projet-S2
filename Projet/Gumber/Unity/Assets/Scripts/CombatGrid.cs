using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class CombatGrid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;

    public CombatGrid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        gridArray = new int[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y), 20, Color.white, TextAnchor.MiddleCenter);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }
}