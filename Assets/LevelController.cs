using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public EnemySpawner[] levels;
    int currentLevel = 0;
    bool levelActive = false;
    public int timeToStartFirstRound = 10; 

    void Start() {
        MenuController.messageUI.StartNextRoundTimer(timeToStartFirstRound);
    }

    public void StartNextLevel() {
        levelActive = true;
        levels[currentLevel].gameObject.SetActive(true);
        MenuController.constructTowerMenu.buyButton.interactable = false;
        MenuController.constructTowerMenu.turretMessage.gameObject.SetActive(true);
        MenuController.constructTowerMenu.turretMessage.text = MenuController.constructTowerMenu.badTimeToPlaceMessage;
    }

    public void EndLevel() {
        levelActive = false;
        CurrencyController.AdjustCurrency(levels[currentLevel].rewardForCompletingLevel);
        levels[currentLevel].gameObject.SetActive(false);
        currentLevel++;

        if (currentLevel >= levels.Length && LivesController.livesLeft > 0) {
            print("You Win!");
            // Display You Win Message
        }
    }

    public EnemySpawner GetLevelObject() {
        return levels[currentLevel];
    }

    public int GetLevelNumber()
    {
        return currentLevel + 1;
    }

    public bool IsLevelActive() {
        return levelActive;
    }

}
