using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player player;
    bool gameOver = false;
    int currentScore;
    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    public void NewGame()
    {
        gameOver = false;
    }
    public void GameOver()
    {
        gameOver = true;
    }
}
