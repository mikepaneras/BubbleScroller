using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    Player player;
    bool hasCollided = false;
    private void Start()
    {
        player = transform.parent.GetComponent<Player>();
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
        hasCollided = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death") && !hasCollided)
        {
            hasCollided = true;
            if (player.getLives() == 0)
            {
                player.Die();
            }
            else
            {
                player.removeLife();
                // Move player to center
                player.transform.position -= new Vector3(player.transform.position.x, 0, 0);
                player.transform.rotation = Quaternion.identity;
            }
        }
        else if (collision.gameObject.tag == "GoldenBubble")
        {
            player.addLife();
        }
    }
}
