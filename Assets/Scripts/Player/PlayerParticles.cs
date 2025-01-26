using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    public ParticleSystem BubblesParticleSystem;

    #region UNITY METHODS
    void Start()
    {
        BubblesParticleSystem = GetComponentInChildren<ParticleSystem>();

    }
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

        #endregion
    }
}
    

