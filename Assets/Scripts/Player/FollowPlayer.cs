using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public bool reset = false;
    Player playerController;
    [SerializeField] Vector2 offset;
    public float followSpeed;

    GameObject resetTarget;

    private void Start()
    {
        playerController = FindFirstObjectByType<Player>();
        player = playerController.gameObject;

        resetTarget = new GameObject("ResetTarget");
        resetTarget.transform.position = Camera.main.transform.position;
    }

    void Update()
    {
        if (playerController.getAlive())
        {
            Vector3 target = player.transform.position + new Vector3(offset.x, offset.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, followSpeed * Time.deltaTime);
        }
        else if (reset)
        {
            float resetSpeed = (Mathf.Clamp01(player.transform.position.y / 300) + 0.01f) * 100 * followSpeed * Time.deltaTime;

            // move camera to start
            transform.position = Vector3.MoveTowards(transform.position, resetTarget.transform.position, resetSpeed);
            
            // move player to center
            player.transform.position = Vector3.MoveTowards(player.transform.position, Camera.main.transform.position + new Vector3(0, -2, 10), resetSpeed);

            // stop the reset animation
            if (Vector3.Distance(transform.position, resetTarget.transform.position) < 0.5f) reset = false;
        }
    }
}
