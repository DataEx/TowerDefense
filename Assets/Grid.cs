using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Grid : MonoBehaviour {

    public Transform walkables;
    public Transform nonWalkables;

    public TwoDTileArray tiles;
    public int xLength;
    public int yLength;

    public List<Tile> navigationPath;

    void Start() {
        AStarUtility.startTile = tiles[0, 0];
        AStarUtility.endTile = tiles[xLength - 1, yLength - 1];
        UpdateNavigationPath();
    }

    public void UpdateNavigationPath() {
        navigationPath = GetShortestPath();
    }

    public List<Tile> GetShortestPath() {
        ResetTileCosts();

        if (AStarUtility.startTile.aStarValues.isObstacle || AStarUtility.endTile.aStarValues.isObstacle)
            return null;

        List<Tile> tilesToExamine = new List<Tile>();
        tilesToExamine.Add(AStarUtility.startTile);
        while(tilesToExamine.Count > 0) {
            Tile currentTile = GetNextExaminedTile(tilesToExamine);

            if (currentTile == AStarUtility.endTile) {
                List<Tile> path = CreateNavigationPath();
                return path;
            }


            List<Tile> surroundingTiles = currentTile.GetSurroundingTiles();
            foreach (Tile neighborTile in surroundingTiles) {
                UpdateAStarValues(currentTile, neighborTile);
                if (!tilesToExamine.Contains(neighborTile)) {
                    tilesToExamine.Add(neighborTile);
                }
            }

            currentTile.aStarValues.hasBeenExamined = true;
            tilesToExamine.Remove(currentTile);
        }

        return null;
    }

    List<Tile> CreateNavigationPath() {
        List<Tile> path = new List<Tile>();
        Tile currentTile = AStarUtility.endTile;
        while (currentTile != null) {
            path.Add(currentTile);
            currentTile = currentTile.aStarValues.parentTile;
        }
        path.Reverse();

        return path;
    }

    Tile GetNextExaminedTile(List<Tile> tilesToExamine) {
        int minHCost = xLength * yLength;
        Tile nextExaminedTile = null;
        foreach (Tile tile in tilesToExamine) {
            if (tile.aStarValues.hCost < minHCost) {
                minHCost = tile.aStarValues.hCost;
                nextExaminedTile = tile;
            }
        }
        return nextExaminedTile;
    }

    void UpdateAStarValues(Tile currentNode, Tile neighborNode) {
        int tempGCost = currentNode.aStarValues.gCost + 1;
        int tempHCost = neighborNode.aStarValues.CalculateHCost();
        int tempFCost = tempGCost + tempHCost;
        if (neighborNode.aStarValues.isNull())
        {
            neighborNode.aStarValues.gCost = tempGCost;
            neighborNode.aStarValues.hCost = tempHCost;
            neighborNode.aStarValues.fCost = tempFCost;
            neighborNode.aStarValues.parentTile = currentNode;
        }
        else {
            if (neighborNode.aStarValues.fCost > tempFCost) {
                neighborNode.aStarValues.gCost = tempGCost;
                neighborNode.aStarValues.hCost = tempHCost;
                neighborNode.aStarValues.fCost = tempFCost;
                neighborNode.aStarValues.parentTile = currentNode;
            }
        }
    }

    void ResetTileCosts() {
        for (int x = 0; x < xLength; x++) {
            for (int y = 0; y < yLength; y++) {
                tiles[x, y].aStarValues.ResetCosts();
            }
        }
    }
}
