using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    [SerializeField] Vector2 offset;
    [SerializeField] float follwSpeed;

    void Update()
    {
        Vector3 target = new Vector3(offset.x, player.position.y + offset.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, follwSpeed * Time.deltaTime);
    }
}
