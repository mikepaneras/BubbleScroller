using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool started = true;

    public Animator animator;

    int livesAmount = 0;
    bool isAlive = true;
    bool isInvincible = false;
    float smoothedSpeed = 0;
    Vector3 target;
    CircleCollider2D colliderPlayer;

    [SerializeField] float speedFalloff = 2f;
    public float rotationSpeed = 1f;
    [SerializeField] Vector2 rotationBounds;
    [SerializeField] float sesitivity = 2f;
    public float speed = 2f;
    [SerializeField] float invincibility = 2f;

    private void Start()
    {
        colliderPlayer = GetComponentInChildren<CircleCollider2D>();
    }

    void Update()
    {
        if (!started) return;

        Rotate();
        if (transform.position.y > -5) transform.position -= Vector3.up * Time.deltaTime;

        if (!isAlive) return;

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
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) direction = -1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) direction = 1f;

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

    public IEnumerator InvicibilityPower()
    {
        isInvincible = true;
        animator.SetBool("isInvincible", true);
        yield return new WaitForSeconds(invincibility);
        animator.SetBool("isInvincible", false);
        isInvincible = false;
    }

    public bool getInvincibilityStatus()
    {
        return isInvincible;
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
    public void Die()
    {
        isAlive = false;
        GetComponent<AudioSource>().Play();
        colliderPlayer.enabled = false;
        
    }

    public void Revive()
    {
        isAlive = true;
        target = transform.position;
        colliderPlayer.enabled = true;
    }
}
