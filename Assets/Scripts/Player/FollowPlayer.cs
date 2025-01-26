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
            // move camera to start
            transform.position = Vector3.Lerp(transform.position, resetTarget.transform.position, followSpeed * Time.deltaTime);
            
            // move player to center
            player.transform.position = Vector3.Lerp(player.transform.position, Camera.main.transform.position + new Vector3(0, -2, 10), 5 * Time.deltaTime);

            // stop the reset animation
            if (Vector3.Distance(transform.position, resetTarget.transform.position) < 0.5f) reset = false;
        }
    }
}
