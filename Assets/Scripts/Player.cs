using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public EnergyBar energyBar { get; private set; }

    [SerializeField] float LeftRightSpeed = 2f;
    [SerializeField] int boost = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        energyBar = FindObjectOfType<EnergyBar>();
    }
    void Update()
    {
        LeftRight();
        Boost();
    }

    void LeftRight()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.position += (rb.transform.right * Time.deltaTime * -LeftRightSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.transform.position += (rb.transform.right * Time.deltaTime * LeftRightSpeed);
        }
    }

    void Boost()
    {
        if (energyBar.GetCurrentEnergy() != 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * boost, ForceMode2D.Force);
            }
        }
        else
        {
            return;
        }
    }
}
