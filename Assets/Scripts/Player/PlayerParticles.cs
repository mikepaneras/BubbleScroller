using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    public ParticleSystem BubblesParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        BubblesParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // Patricles on movement
                    
                BubblesParticleSystem.Play();
            
   
        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            // Stop making particles
            BubblesParticleSystem.Stop();
        }
        
    }
}
