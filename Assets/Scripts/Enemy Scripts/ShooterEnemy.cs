using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    Player player;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float shootDelay = 1;
    [SerializeField] Vector3 bulletSpawnOffset = Vector3.zero;
    [SerializeField] float attackRange = 3;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        Shoot();
    }
    void Shoot()
    {
        StartCoroutine(ShootCoroutine());
    }
    IEnumerator ShootCoroutine()
    {
        while(player.getAlive())
        {
            yield return new WaitForSeconds(shootDelay);

            if(player.getAlive() && Vector3.Distance(transform.position, player.transform.position) <= attackRange)
            {
                Instantiate(bulletPrefab, transform.position + bulletSpawnOffset, Quaternion.identity);
            }
        }
    }
}
