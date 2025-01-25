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
    bool triggerPassed = false;
    // Start is called before the first frame update
    void Start()
    {
        messageObject.text = messageText;
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerPassed && hasDisplayTimer)
        {
            if(displayTimer > 0)
            {
                displayTimer -= Time.deltaTime;
                return;
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerPassed = true;
        messageObject.gameObject.SetActive(true);
    }
}
