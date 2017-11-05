using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructTurretMenu : Menu {

    public Turret turretForSale;

    public void SetTowerInGrid() {
        Tile tile = Tile.activeTile;
        if (tile.turret == null) {
            Tile.activeTile.SetTurret(Instantiate(turretForSale));
            tile.SetNotWalkable();
        }
        MenuController.SetActiveMenu(MenuController.turretDetailMenu);

    }

}
