using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarDamageFoe : MonoBehaviour
{
    Player player;
    [SerializeField] int barDamage = 25;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.energyBar.DecreaseEnergy(barDamage);
            Debug.Log("Player Bar Got Damaged");
        }
    }
}

