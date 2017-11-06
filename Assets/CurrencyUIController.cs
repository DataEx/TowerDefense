using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyUIController : MonoBehaviour {


    public Text currencyText;

    public void UpdateCurrency() {
        currencyText.text = CurrencyController.currencyAvailable.ToString();
        MenuController.RecheckAfforadability();
    }


}
