using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    bool isAlive = true;
    bool isBoosting = false;
    //public EnergyBar energyBar { get; private set; }

    [SerializeField] float normalSpeed = 2f;
    [SerializeField] float boostSpeed = 1.5f;
    [SerializeField] int boost = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        LeftRight();
        Boost();
        CheckBounds();
    }

    private void CheckBounds()
    {
        //if (transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).y)
    }

    void LeftRight()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.position += (rb.transform.right * Time.deltaTime * -(isBoosting ? boostSpeed : normalSpeed));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.transform.position += (rb.transform.right * Time.deltaTime * (isBoosting ? boostSpeed : normalSpeed));
        }
    }

    void Boost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isBoosting = true;
            rb.AddForce(Vector2.up * boost, ForceMode2D.Force);
        }
        else isBoosting = false;
    }

    public bool getAlive() => isAlive;

    public void Die()
    {
        isAlive = false;
    }
}
