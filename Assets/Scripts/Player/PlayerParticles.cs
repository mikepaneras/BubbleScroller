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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Patricles on movement
                    
                BubblesParticleSystem.Play();
            
   
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            // Stop making particles
            BubblesParticleSystem.Stop();
        }
        
    }
}
