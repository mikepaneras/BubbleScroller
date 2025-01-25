using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = transform.parent.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle") && player.getLives() == 0)
        {
            player.Die();
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle") && player.getLives() != 0)
        {
            player.removeLife();
        }
        else if (collision.gameObject.tag == "GoldenBubble")
        {
            player.addLife();
        }
    }
}
