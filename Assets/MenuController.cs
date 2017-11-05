using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public ConstructTurretMenu constructTowerMenuPublic;
    public static ConstructTurretMenu constructTowerMenu;

    public TurretDetailMenu turretDetailMenuPublic;
    public static TurretDetailMenu turretDetailMenu;

    static Menu[] menus;

    void Awake() {
        constructTowerMenu = constructTowerMenuPublic;
        turretDetailMenu = turretDetailMenuPublic;

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
}
