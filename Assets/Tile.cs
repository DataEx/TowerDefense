using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public Coordinate coordinate;

    public static Tile activeTile;

    Color mouseOverColor = Color.yellow;
    Color mouseClickColor = Color.red;
    Color originalColor;
    Renderer renderer;
    public Grid grid;

    public Turret turret;

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
        this.transform.parent = grid.nonWalkables;
        grid.ResetNavMesh();
    }

    public void SetWalkable()
    {
        this.transform.parent = grid.walkables;
        grid.ResetNavMesh();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Set Tile Color 
            if (activeTile != null) {
                activeTile.GetComponent<Renderer>().material.color = originalColor;
            }
            renderer.material.color = mouseClickColor;

            // Set Active Menu
            if (turret == null)
            {
                MenuController.SetActiveMenu(MenuController.constructTowerMenu);
            }
            else {
                MenuController.SetActiveMenu(MenuController.turretDetailMenu);
            }

            activeTile = this;
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
}
