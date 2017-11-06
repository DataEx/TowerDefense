using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;


[Serializable]
public class TwoDTileArray
{
    [SerializeField]
    private int width;

    [SerializeField]
    private int height;

    [SerializeField]
    private Tile[] values;

    public int Width { get { return width; } }

    public int Height { get { return height; } }

    public Tile this[int x, int y]
    {
        get { return values[y * width + x]; }
        set { values[y * width + x] = value; }
    }

    public TwoDTileArray(int width, int height)
    {
        this.width = width;
        this.height = height;

        values = new Tile[width * height];
    }
}
