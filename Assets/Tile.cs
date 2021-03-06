﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour {

    public Coordinate coordinate;

    public static Tile activeTile;

    Color mouseOverColor = Color.yellow;
    Color mouseClickColor = Color.red;
    Color originalColor;
    Renderer renderer;
    public Grid grid;

    public Turret turret;

    public AStarUtility aStarValues;


    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }

    public void SetTurret(Turret newTurret)
    {
        turret = newTurret;
        turret.transform.parent = this.transform;
        turret.transform.localPosition = Vector3.zero;
    }

    public void SetNotWalkable() {
        aStarValues.isObstacle = true;
        grid.UpdateNavigationPath();
    }

    public void SetWalkable()
    {
        aStarValues.isObstacle = false;
        grid.UpdateNavigationPath();
    }

    void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if (Input.GetMouseButtonDown(0))
            {
            // Set Tile Color 
            if (activeTile != null) {
                activeTile.GetComponent<Renderer>().material.color = originalColor;
            }
            renderer.material.color = mouseClickColor;

            activeTile = this;

            // Set Active Menu
            if (turret == null)
            {
                MenuController.constructTowerMenu.CheckBuyAbility();
                MenuController.SetActiveMenu(MenuController.constructTowerMenu);
            }
            else {
                MenuController.SetActiveMenu(MenuController.turretDetailMenu);
                MenuController.turretDetailMenu.UpdateUI();
            }
        }

        if(this != activeTile){
            renderer.material.color = mouseOverColor;
        }
    }

    void OnMouseExit()
    {

        if (activeTile != this) {
            renderer.material.color = originalColor;
        }
    }



    public List<Tile> GetSurroundingTiles() {
        int gridX = grid.xLength;
        int gridY = grid.yLength;
        int thisX = coordinate.x;
        int thisY = coordinate.y;
        List<Tile> surroundingTiles = new List<Tile>();

        // Check up
        if (thisY < gridY - 1) {
            if(grid.tiles[thisX, thisY + 1].aStarValues.NeedsToBeChecked())
                surroundingTiles.Add(grid.tiles[thisX, thisY + 1]);
        }
        // Check right
        if (thisX < gridX - 1)
        {
            if (grid.tiles[thisX + 1, thisY].aStarValues.NeedsToBeChecked())
                surroundingTiles.Add(grid.tiles[thisX + 1, thisY]);
        }
        // Check left 
        if (thisX > 0)
        {
            if (grid.tiles[thisX - 1, thisY].aStarValues.NeedsToBeChecked())
                surroundingTiles.Add(grid.tiles[thisX - 1, thisY]);
        }

        // Check down 
        if (thisY > 0)
        {
            if (grid.tiles[thisX, thisY - 1].aStarValues.NeedsToBeChecked())
                surroundingTiles.Add(grid.tiles[thisX, thisY - 1]);
        }

        return surroundingTiles;
    }
}
