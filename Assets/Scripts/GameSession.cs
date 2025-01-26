using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    public Player player;
    public GameObject deathScreen;
    public TextMeshProUGUI livesAmounts;
    
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
            deathScreen.gameObject.SetActive(true);
        }
    }

    void CheckGainLives()
    {
        if (livesAmounts.text != player.getLives().ToString())
        {
            livesAmounts.SetText(player.getLives().ToString());
        }
    }
}
