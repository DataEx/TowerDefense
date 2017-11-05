using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Coordinate{

        public int x;
        public int y;

        public Coordinate(int xCoord, int yCoord)
        {
            x = xCoord;
            y = yCoord;
        }

        public void SetCoord(int xCoord, int yCoord)
        {
            x = xCoord;
            y = yCoord;
        }


}
