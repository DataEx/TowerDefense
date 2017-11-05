using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {


    public void EnableMenu() {
        this.gameObject.SetActive(true);
    }


    public void DisableMenu()
    {
        this.gameObject.SetActive(false);
    }

}
