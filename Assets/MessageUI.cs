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

    void Awake() {
        messages = new GameObject[] { timerMessage, congratulationsMessage, enemiesRemainingMessage };
    }

    void SetMessageActive(GameObject currentMessage) {
        foreach (GameObject message in messages) {
            message.SetActive(message == currentMessage);
        }
    }
}
