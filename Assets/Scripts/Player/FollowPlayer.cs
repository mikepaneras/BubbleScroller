using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Player player;
    [SerializeField] Vector2 offset;
    [SerializeField] float followSpeed;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    void Update()
    {
        if (player.getAlive())
        {
            Vector3 target = new Vector3(offset.x, player.transform.position.y + offset.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, followSpeed * Time.deltaTime);
        }
    }
}
