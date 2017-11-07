using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageUI : MonoBehaviour {

    public GameObject timerMessage;
    public Text timeRemainingText;

    public GameObject congratulationsMessage;
    public Text congratulationsRoundText;
    public Text congratulationsRewardText;

    public GameObject enemiesRemainingMessage;
    public Text enemiesRemainingText;

    GameObject[] messages;

    public LevelController levelController;

    void Awake() {
        messages = new GameObject[] { timerMessage, congratulationsMessage, enemiesRemainingMessage };
    }


    public void StartNextRoundTimer(int timeToNextRound)
    {
        SetMessageActive(timerMessage);
        StartCoroutine(CountdownToNextRound(timeToNextRound));
    }

    IEnumerator CountdownToNextRound(int timeToNextRound) {
        while (timeToNextRound >= 0) {
            timeRemainingText.text = timeToNextRound.ToString();
            yield return new WaitForSecondsRealtime(1f);
            timeToNextRound--;
        }
        levelController.StartNextLevel();
        SetEnemiesRemainingMessageActive();
    }

    void SetCongratulationsMessage(string roundNumber, string reward) {
        congratulationsRoundText.text = roundNumber;
        congratulationsRewardText.text = reward;
        SetMessageActive(congratulationsMessage);

        if (levelController.GetLevelNumber() < levelController.levels.Length) {
            StartCoroutine(WaitBetweenCongratulationAndNextRoundMessages());
        }
    }

    IEnumerator WaitBetweenCongratulationAndNextRoundMessages() {
        yield return new WaitForSecondsRealtime(5f);
        StartNextRoundTimer(10);
    }

    void SetEnemiesRemainingMessageActive() {
        enemiesRemainingText.text = levelController.GetLevelObject().enemiesToSpawn.ToString(); 
        SetMessageActive(enemiesRemainingMessage);
    }

    public void UpdateEnemiesRemaining(int enemiesRemaining) {
        enemiesRemainingText.text = enemiesRemaining.ToString();

        if (enemiesRemaining == 0) {
            string roundNumber = levelController.GetLevelNumber().ToString();
            string reward = "$" + levelController.GetLevelObject().rewardForCompletingLevel.ToString();
            SetCongratulationsMessage(roundNumber, reward);
        }
    }

    void SetMessageActive(GameObject currentMessage) {
        foreach (GameObject message in messages) {
            message.SetActive(message == currentMessage);
        }
    }


}
