using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Transform player;
    [SerializeField] float bulletSpeed;
    Vector3 direction;
    float destroyDelay = 5;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyDelay);
        tag = "Death";
        GetComponent<Collider2D>().isTrigger = true;
        player = FindObjectOfType<Player>().transform;
        direction = player.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * bulletSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
