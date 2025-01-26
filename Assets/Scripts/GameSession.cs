using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    public Player player;
    public GameObject deathScreen;
    public TextMeshProUGUI livesAmounts;
    public FollowPlayer cameraController;
    
    // Update is called once per frame
    void Update()
    {
        ChcekAlive();
        CheckGainLives();
    }

    void ChcekAlive()
    {
        if (!player.getAlive())
        {
            ResetAnimation();
        }
    }

    float timer;
    bool resetting = false;
    float initialPause = 3f; // how long to wait before starting to go back to the bottom. (second)

    void ResetAnimation()
    {
        if (timer < initialPause)
        {
            timer += Time.deltaTime;
            return;
        }
        else if (!resetting)
        {
            resetting = true;
            cameraController.reset = true; // stop following the player
        }

        // Wait until the camera has reached the bottom.
        if (cameraController.reset == true) return;
        resetting = false;

        player.Revive(); // enable player controller
    }

    void CheckGainLives()
    {
        if (livesAmounts.text != player.getLives().ToString())
        {
            livesAmounts.SetText(player.getLives().ToString());
        }
    }
}
