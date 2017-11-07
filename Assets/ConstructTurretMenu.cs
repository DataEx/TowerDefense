using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructTurretMenu : Menu {

    public Turret turretForSale;
//    public int turretPrice;
    public Button buyButton;

    public Text turretPriceText;

    public Text turretMessage;
    public string insufficientFundsMessage;
    public string badTurretPlacementMessage;
    public string badTimeToPlaceMessage;

    void Start() {
        turretPriceText.text = "$" + turretForSale.cost.ToString();
    }

    public void CheckBuyAbility() {
        if (Tile.activeTile != null) {
            if (MenuController.messageUI.levelController.GetLevelObject().isActiveAndEnabled) {
                buyButton.interactable = false;
                turretMessage.gameObject.SetActive(true);
                turretMessage.text = badTimeToPlaceMessage;
            }
            else if (CurrencyController.CanAfford(turretForSale.cost))
                if (DoesPathAllowTurretConstruction())
                {
                    buyButton.interactable = true;
                    turretMessage.gameObject.SetActive(false);
                }
                else
                {
                    buyButton.interactable = false;
                    turretMessage.gameObject.SetActive(true);
                    turretMessage.text = badTurretPlacementMessage;
                }
            else {
                turretMessage.gameObject.SetActive(true);
                turretMessage.text = insufficientFundsMessage;
            }
        }
    }


    public void SetBuyButtonActive(bool active) {
        if (!MenuController.messageUI.levelController.IsLevelActive())
        {
            buyButton.interactable = active;
            turretMessage.gameObject.SetActive(false);
        }
        else {
            buyButton.interactable = false;
            turretMessage.gameObject.SetActive(true);
            turretMessage.text = badTimeToPlaceMessage;
        }

    }

    bool DoesPathAllowTurretConstruction()
    {
        Tile tile = Tile.activeTile;
        tile.aStarValues.isObstacle = true;
        bool pathExists = tile.grid.GetShortestPath() != null;
        tile.aStarValues.isObstacle = false;
        return pathExists;
    }

    void SetTowerInGrid() {
        Tile tile = Tile.activeTile;
        if (tile.turret == null) {
            tile.SetTurret(Instantiate(turretForSale));
            tile.SetNotWalkable();
                        
        }

    }

    public void BuyTurret() {
        MenuController.turretDetailMenu.currentTower = turretForSale;
        CurrencyController.AdjustCurrency(-turretForSale.cost);
        SetTowerInGrid();
        MenuController.SetActiveMenu(MenuController.turretDetailMenu);
    }

}
