using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructTurretMenu : Menu {

    public Turret turretForSale;
    public int turretPrice;
    public Button buyButton;

    void SetTowerInGrid() {
        Tile tile = Tile.activeTile;
        if (tile.turret == null) {
            Tile.activeTile.SetTurret(Instantiate(turretForSale));
            tile.SetNotWalkable();
                        
        }

    }

    public void BuyTurret() {
        CurrencyController.AdjustCurrency(-turretPrice);


        SetTowerInGrid();
        MenuController.SetActiveMenu(MenuController.turretDetailMenu);
    }

}
