using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    int livesAmount = 0;
    bool isAlive = true;
    bool isInvincible = false;
    float smoothedSpeed = 0;
    Vector3 target;
    Rigidbody2D rb;

    [SerializeField] float speedFalloff = 2f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] Vector2 rotationBounds;
    [SerializeField] float sesitivity = 2f;
    [SerializeField] float speed = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isAlive) return;

        Rotate();
        transform.position -= Vector3.up * Time.deltaTime;

        // Move up.
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            target = transform.position + transform.up; // Target a point if front of the player

            // Start increasing speed
            smoothedSpeed = Mathf.Lerp(smoothedSpeed, speed, speedFalloff * Time.deltaTime);
        }
        else
        {
            // Start decreasing speed
            smoothedSpeed = Mathf.Lerp(smoothedSpeed, 0, speedFalloff * Time.deltaTime);
        }
        // Move player
        transform.position = Vector3.Lerp(transform.position, target, smoothedSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        // Get input
        float direction = Input.GetAxis("Mouse X") * sesitivity;
        if (Input.GetKey(KeyCode.A)) direction = -1f;
        if (Input.GetKey(KeyCode.D)) direction = 1f;

        // format value for calculations
        float rotation = transform.eulerAngles.z;
        if (rotation > 180f) rotation -= 360f;

        // Rotate player
        if (rotation >= rotationBounds.x && rotation <= rotationBounds.y) transform.Rotate(new Vector3(0, 0, direction * rotationSpeed * Time.deltaTime));

        // format the new value for the next calculations
        rotation = transform.eulerAngles.z;
        if (rotation > 180f) rotation -= 360f;

        // Clamp rotation
        if (rotation <= rotationBounds.x) transform.rotation = Quaternion.Euler(0, 0, rotationBounds.x + 0.01f);
        if (rotation >= rotationBounds.y) transform.rotation = Quaternion.Euler(0, 0, rotationBounds.y - 0.01f);
    }

    IEnumerator InvicibilityPower()
    {
        isInvincible = true;
        yield return new WaitForSeconds(0.5f);
        isInvincible = false;
    }

    public int getLives() => livesAmount;

    public void addLife()
    {
        livesAmount++;
    }

    public void removeLife()
    {
        livesAmount--;
    }

    public bool getAlive() => isAlive;
    public void Die() => isAlive = false;
}
