using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    public ParticleSystem BubblesParticleSystem;
    public AudioSource audioSource;

    Player player;

    #region UNITY METHODS
    void Start()
    {
        BubblesParticleSystem = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        player = GetComponentInParent<Player>();

        BubblesParticleSystem.Stop();
        audioSource.Stop();
    }

    void Update()
    {
        if (player.getAlive() && player.started && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            // Patricles on movement
            audioSource.Play();
            BubblesParticleSystem.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            // Stop making particles
            BubblesParticleSystem.Stop();
            audioSource.Stop();
        }

        #endregion
    }
}
    

