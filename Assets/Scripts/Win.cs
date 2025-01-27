using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public FollowPlayer cameraController;
    public GameObject cameraFinishTarget;
    public Player player;
    bool finished;
    [SerializeField] GameObject outro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, cameraFinishTarget.transform.position, cameraController.followSpeed * Time.deltaTime);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.identity, player.rotationSpeed * Time.deltaTime);
            player.transform.position += player.transform.up * player.speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        finished = true;
        cameraController.enabled = false;
        player.enabled = false;
        outro.SetActive(true);
    }
}
