using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public ConstructTurretMenu constructTowerMenuPublic;
    public static ConstructTurretMenu constructTowerMenu;

    public TurretDetailMenu turretDetailMenuPublic;
    public static TurretDetailMenu turretDetailMenu;

    public CurrencyUIController currencyUIPublic;
    public static CurrencyUIController currencyUI;


    static Menu[] menus;

    void Awake() {
        constructTowerMenu = constructTowerMenuPublic;
        turretDetailMenu = turretDetailMenuPublic;
        currencyUI = currencyUIPublic;

        menus = new Menu[] { constructTowerMenu, turretDetailMenu };
    }

    public static void SetActiveMenu(Menu activeMenu) {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i] == activeMenu)
                menus[i].EnableMenu();
            else
                menus[i].DisableMenu();
        }
    }

    public static void RecheckAfforadability() {
        int currencyAvailable = CurrencyController.currencyAvailable;
        constructTowerMenu.buyButton.interactable = constructTowerMenu.turretPrice <= currencyAvailable;
        turretDetailMenu.upgradeButton.interactable = turretDetailMenu.upgradeCost <= currencyAvailable;
    }

    //void ToggleButtonVisibility
}
