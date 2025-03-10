using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    bool startFade = false;
    bool startIntro = false;
    float delay = 0f;
    float fadeSpeed = 0.5f;
    public Image image;
    public TextMeshProUGUI textMeshPro;

    public Image outroimage;
    public TextMeshProUGUI textoutro;

    public Player player;
    public PlayerParticles particles;

    void Start()
    {
        image.gameObject.SetActive(true);
        FadeIN();
        Invoke("FadeOut", 6f);
        Invoke("UnlockPlayer", 12f);
    }

    void UnlockPlayer()
    {
        player.started = true;
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            particles.audioSource.Play();
            particles.BubblesParticleSystem.Play();
        }
    }

    void FadeOut()
    {
        startIntro = false;
        startFade = true;
    }

    void FadeIN()
    {
        textMeshPro.color = new Color(1, 1, 1, 0);
        startIntro = true;
        startFade = false;
    }

    void Update()
    {
        if (startFade)
        {
            image.color -= new Color(0,0,0, Time.deltaTime * fadeSpeed);
            textMeshPro.color -= new Color(0, 0, 0, Time.deltaTime * fadeSpeed);
        }

        if (startIntro)
        {
            if(delay > 0) { delay -= Time.deltaTime; return; }
            image.color += new Color(0, 0, 0, Time.deltaTime * fadeSpeed);
            textMeshPro.color += new Color(0, 0, 0, Time.deltaTime * fadeSpeed);
        }
    }
}
