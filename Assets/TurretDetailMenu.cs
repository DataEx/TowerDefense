using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretDetailMenu : Menu {

//    public int upgradeCost = 50;
//    public int sellReturn = 25;

    public Text upgradeCostText;
    public Text sellValueText;

    public Button upgradeButton;
    public Button sellButton;

    public Turret currentTower;

    void OnEnable() {
        UpdateUI();
    }

    public void UpdateUI() {
        currentTower = Tile.activeTile.turret;
        if (currentTower.upgradesTo != null)
        {
            if (CurrencyController.CanAfford(currentTower.upgradesTo.cost))
                SetUpgradeButtonActive(true);
            upgradeCostText.text = "-$" + currentTower.upgradesTo.cost.ToString();
        }
        else
        {
            SetUpgradeButtonActive(false);
        }
        sellValueText.text = "$" + currentTower.sellValue.ToString();
    }

    public void UpgradeTurret() {
        int upgradeCost = currentTower.upgradesTo.cost;

        Destroy(Tile.activeTile.turret.gameObject);
        currentTower = Instantiate(currentTower.upgradesTo);
        Tile.activeTile.SetTurret(currentTower);

        if (currentTower.upgradesTo == null)
        {
            SetUpgradeButtonActive(false);
        }
        sellValueText.text = "$" + currentTower.sellValue.ToString();


        CurrencyController.AdjustCurrency(-upgradeCost);

    }

    public void SellTurret() {
        CurrencyController.AdjustCurrency(currentTower.sellValue);
        Tile tile = Tile.activeTile;
        Destroy(tile.turret.gameObject);
        tile.SetWalkable();
        MenuController.SetActiveMenu(MenuController.constructTowerMenu);
    }

    public void SetUpgradeButtonActive(bool active) {
        upgradeButton.interactable = active;

        if (currentTower.upgradesTo == null)
        {
            upgradeCostText.gameObject.SetActive(false);

        }
        else {
            upgradeCostText.gameObject.SetActive(true);
        }
    }

}
