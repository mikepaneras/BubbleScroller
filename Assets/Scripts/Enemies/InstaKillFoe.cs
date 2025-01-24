using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKillFoe : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.Die();
            Debug.Log("I killed the player");
        }
    }
}
