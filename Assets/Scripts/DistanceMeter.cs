using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    //Assign vars...
    public TextMeshProUGUI counterDistance;
    public float counter = Mathf.NegativeInfinity;
    public GameObject bubble;

    
    private void Start()
    // Ref to player...
    {
        bubble = FindFirstObjectByType<Player>().gameObject;     
    }
    void Update()
    // Update counter when current position of the player is the new high score...
    {       
        if(bubble.transform.position.y > counter)
        {
            counter = bubble.transform.position.y;
        }

        // Display the message on screen...
        counterDistance.text = $"Longest Journey  { ((int)counter)}";
    }
    // Max distance is 390m
}
