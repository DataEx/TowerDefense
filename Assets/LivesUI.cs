using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

    public Text livesRemainingText;

    public void UpdateLives() {
        livesRemainingText.text = LivesController.livesLeft.ToString();
    }
}
