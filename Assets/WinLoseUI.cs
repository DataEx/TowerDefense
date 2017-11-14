using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseUI : MonoBehaviour {

    public GameObject canvas;
    public GameObject winUI;
    public GameObject loseUI;

    public void EnableWinUI() {
        canvas.SetActive(true);
        winUI.SetActive(true);
        loseUI.SetActive(false);
        MenuController.messageUI.gameObject.SetActive(false);
    }

    public void EnableLoseUI() {
        canvas.SetActive(true);
        loseUI.SetActive(true);
        winUI.SetActive(false);
        MenuController.messageUI.gameObject.SetActive(false);
    }

    public void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
