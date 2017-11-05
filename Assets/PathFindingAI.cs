using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingAI : MonoBehaviour {

    List<Tile> route;
    public GameObject grid;
    public Coordinate startCoordinate;
    public Coordinate endCoordinate;

    void GenerateRoute() {
        route = new List<Tile>();

    }


}
