using UnityEngine;

public class Player : MonoBehaviour
{
    bool isAlive = true;
    [SerializeField] float speed = 2f;
    float smoothedSpeed = 0;
    [SerializeField] float speedFalloff = 2f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] Vector2 rotationBounds;
    [SerializeField] float sesitivity = 2f;
    Vector3 target;

    void Update()
    {
        Rotate();

        if (!isAlive) return;

        // Move up.
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            target = transform.position + transform.up;

            smoothedSpeed = Mathf.Lerp(smoothedSpeed, speed, speedFalloff * Time.deltaTime);
        }
        else
        {
            smoothedSpeed = Mathf.Lerp(smoothedSpeed, 0, speedFalloff * Time.deltaTime);
        }
        transform.position = Vector3.Lerp(transform.position, target, smoothedSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        float direction = Input.GetAxis("Mouse X") * sesitivity;
        if (Input.GetKey(KeyCode.A)) direction = -1f;
        if (Input.GetKey(KeyCode.D)) direction = 1f;

        float rotation = transform.eulerAngles.z;
        if (rotation > 180f) rotation -= 360f;

        if (rotation >= rotationBounds.x && rotation <= rotationBounds.y) transform.Rotate(new Vector3(0, 0, direction * rotationSpeed * Time.deltaTime));

        rotation = transform.eulerAngles.z;
        if (rotation > 180f) rotation -= 360f;

        // Clamp indicator
        if (rotation <= rotationBounds.x) transform.rotation = Quaternion.Euler(0, 0, rotationBounds.x + 0.01f);
        if (rotation >= rotationBounds.y) transform.rotation = Quaternion.Euler(0, 0, rotationBounds.y - 0.01f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Finish" && !isInvincible)
        {
            if (livesAmount == 0) Die();
            else
            {
                livesAmount--;
                StartCoroutine(InvicibilityPower());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "GoldenBubble")
        {
            //Add invicibility logic
            livesAmount++;
        }
    }
    IEnumerator InvicibilityPower()
    {
        isInvincible = true;
        yield return new WaitForSeconds(0.5f);
        isInvincible = false;
    }
    public bool getAlive() => isAlive;

    public void Die()
    {
        isAlive = false;
    }
}
