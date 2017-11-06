using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public EnemySpawner[] levels;
    int currentLevel = 0;

    void StartNextLevel() {
        levels[currentLevel].gameObject.SetActive(true);
    }

    public void EndLevel() {
        CurrencyController.AdjustCurrency(levels[currentLevel].rewardForCompletingLevel);
        levels[currentLevel].gameObject.SetActive(false);
        currentLevel++;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartNextLevel();
        }
    }


}
