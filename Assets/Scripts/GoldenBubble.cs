using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBubble : MonoBehaviour
{
    CircleCollider2D circleCollider2D;

    bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        isAlive = true;
    }

    private void Update()
    {
        CheckAlive();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isAlive = false;
            Debug.Log("Gold Bubble Get!");
        }
    }

    void CheckAlive()
    {
        if (!isAlive) Destroy(this.gameObject);
    }
}
