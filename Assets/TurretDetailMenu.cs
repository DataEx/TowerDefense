using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretDetailMenu : Menu {

    public int upgradeCost = 50;
    public int sellReturn = 25;

    public Text upgradeCostText;
    public Text sellValueText;

    public Button upgradeButton;
    public Button sellButton;

    public void UpgradeTurret() {
        CurrencyController.AdjustCurrency(-upgradeCost);

        print("Upgrade");
    }

    public void SellTurret() {
        CurrencyController.AdjustCurrency(sellReturn);


        Tile tile = Tile.activeTile;
        Destroy(tile.turret.gameObject);
        tile.SetWalkable();
        MenuController.SetActiveMenu(MenuController.constructTowerMenu);

    }

}
