using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    //Assign vars...
    public TextMeshProUGUI counterDistance;
    public float counter = 0;
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
        counterDistance.text = $"Peak Journey:  { ((int)counter)}";

        if (counter < 0)
        {
            counterDistance.enabled = false;
        }
        else
        {
            counterDistance.enabled = true;
        }

    }
    // Max distance is 390m

    public void SetTransparency(float alpha)
    {
        Color color = counterDistance.color;
        color.a = alpha;
        counterDistance.color = color;
    }
}
