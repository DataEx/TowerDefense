using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour {

    public static int livesLeft;
    public int startingLives;

    void Start () {
        livesLeft = startingLives;
        MenuController.livesUI.UpdateLives();
    }

    public static void DecrementLives()
    {
        livesLeft = Mathf.Max(livesLeft - 1, 0);
        MenuController.livesUI.UpdateLives();
        if (livesLeft == 0) {
            print("Game Over");
        //    DisplayGameOver();
        }
    }
}
