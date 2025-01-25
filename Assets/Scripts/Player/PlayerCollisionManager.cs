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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            player.Die();
        }
    }
}
