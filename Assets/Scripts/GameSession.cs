using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public Player player;
    public Canvas deathScreen;
    
    // Update is called once per frame
    void Update()
    {
        ChcekAlive();
    }

    void ChcekAlive()
    {
        if (!player.getAlive())
        {
            player.gameObject.SetActive(false);
            deathScreen.gameObject.SetActive(true);
        }
    }
}
