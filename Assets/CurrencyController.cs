using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyController : MonoBehaviour {

    public static int currencyAvailable;
    public int startingCurrency;

    void Start() {
        currencyAvailable = startingCurrency;
        MenuController.currencyUI.UpdateCurrency();
    }

    public static void AdjustCurrency(int diff) {
        currencyAvailable += diff;
        MenuController.currencyUI.UpdateCurrency();
    }

    public static bool CanAfford(int cost)
    {
        return cost <= currencyAvailable;
    }
}
