using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    bool startFade = false;
    bool startIntro = false;
    public Image image;
    public TextMeshProUGUI textMeshPro;

    public Image outroimage;
    public TextMeshProUGUI textoutro;
    void Start()
    {
        Invoke("FadeOut", 6f);
    }

    void FadeOut()
    {
        startFade = true;
    }

    void FadeIN()
    {
        startIntro = true;
    }

    void Update()
    {
        if (startFade)
        {
            image.color -= new Color(0,0,0, Time.deltaTime);
            textMeshPro.color -= new Color(0, 0, 0, Time.deltaTime);
        }

        if (startIntro)
        {
            image.color += new Color(0, 0, 0, Time.deltaTime);
            textMeshPro.color += new Color(0, 0, 0, Time.deltaTime);
        }
    }
}
