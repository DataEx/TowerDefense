using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AStarUtility
{
    public int gCost; // distance from starting node
    public int hCost; // distance from endNode 
    public int fCost; // sum of g + hs
    public bool hasBeenExamined;

    public static Tile startTile;
    public static Tile endTile;

    public Coordinate tileCoordinate;

    public bool isObstacle = false;

    public Tile parentTile; // Tile in path which last updated this tile

    public bool isNull() {
        return gCost == 0 && hCost == 0;
    }


    public bool NeedsToBeChecked() {
        return !isObstacle && !hasBeenExamined;
    }

    public void ExamineSurroundingNodes() {

    }

    public int CalculateHCost() {
        int xDiff = Mathf.Abs(endTile.coordinate.x - tileCoordinate.x);
        int yDiff = Mathf.Abs(endTile.coordinate.y - tileCoordinate.y);
        return xDiff + yDiff;
    }

    public void ResetCosts() {
        fCost = 0;
        gCost = 0;
        hCost = 0;
        hasBeenExamined = false;
        parentTile = null;
    }
}