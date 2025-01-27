using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Message : MonoBehaviour
{
    [SerializeField] TextMeshPro messageObject;
    [SerializeField] string messageText;
    [SerializeField] bool hasDisplayTimer;
    [SerializeField] float displayTimer;
    float counter = 0;
    bool triggerPassed = false;
    // Start is called before the first frame update
    void Start()
    {
        messageObject.text = messageText;
        if(hasDisplayTimer)
        {
            messageObject.color = new Color(1, 1, 1, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerPassed && hasDisplayTimer)
        {       
            if(displayTimer > 0)
            {
                messageObject.color += new Color(0, 0, 0, Time.deltaTime);
                displayTimer -= Time.deltaTime;
                return;
            }
            if(messageObject.color.a > 0)
            {
                messageObject.color -= new Color(0, 0, 0, Time.deltaTime);
                counter += Time.deltaTime;
                return;
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            triggerPassed = true;
            messageObject.gameObject.SetActive(true);
        }
    }
}
