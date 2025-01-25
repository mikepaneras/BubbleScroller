using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Player player;
    [SerializeField] Vector2 offset;
    [SerializeField] float follwSpeed;

    void Update()
    {
        if (player.getAlive())
        {
            Vector3 target = new Vector3(offset.x, player.transform.position.y + offset.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, follwSpeed * Time.deltaTime);
        }
    }
}
