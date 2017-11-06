using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour {

    List<Tile> tiles = new List<Tile>();

    public Tile tilePrefab;

    public int xLength;
    public int yLength;

    public Grid gridPrefab;

    //void Awake()
    //{
    //    CreateGrid();
    //}


    public void CreateGrid() {
        Grid grid = Instantiate(gridPrefab) as Grid;
        grid.xLength = xLength;
        grid.yLength = yLength;
        grid.tiles = new TwoDTileArray(xLength, yLength);
        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                Tile tile = CreateTile(new Coordinate(x,y), grid);
                grid.tiles[x,y] = tile;
                if (x == 0 && y == 0)
                {
                    AStarUtility.startTile = tile;
                    print(AStarUtility.startTile);
                }
                else if (x == xLength - 1 && y == yLength - 1) {
                    AStarUtility.endTile = tile;
                    print(AStarUtility.endTile);
                }
            }
        }
    }


    Tile CreateTile(Coordinate coordiante, Grid grid) {
        Tile tile = Instantiate(tilePrefab, grid.walkables);
        tile.coordinate = coordiante;
        tile.transform.localPosition = new Vector3(coordiante.x * GetTileLength(), 0,
            coordiante.y * GetTileLength());
        tile.name = "Tile (" + coordiante.x + ", " + coordiante.y + ")";
        tile.grid = grid;

        return tile;
    }


    float GetTileLength() {
        return tilePrefab.GetComponent<Renderer>().bounds.size.x;
    }
}
