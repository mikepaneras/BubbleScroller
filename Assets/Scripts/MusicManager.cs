using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    [Serializable]
    struct Track
    {
        public string name;
        public AudioMixerGroup group;
    }

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Track[] tracks;
    [SerializeField] int selectedTrack = 0;
    [SerializeField] int previousTrack = 0;
    [SerializeField] float transitionSpeed = 3f;


    [SerializeField] int transitionTo;
    [SerializeField] bool transition;

    void Start()
    {
        for (int i = 0; i < tracks.Length; i++)
        {
            if (i == selectedTrack) audioMixer.SetFloat($"Vol_{i}", 0f);
            else audioMixer.SetFloat($"Vol_{i}", -80f);
        }
    }

    void Update()
    {
        if(transition)
        {
            transition = false;
            ChangeMusic(transitionTo);
        }

        float volume;

        if (previousTrack != selectedTrack)
        {
            // Mute previous.
            audioMixer.GetFloat($"Vol_{previousTrack}", out volume);
            if (volume == -80f) previousTrack = selectedTrack;
            else
            {
                volume = Mathf.MoveTowards(volume, -80f, transitionSpeed * Time.deltaTime);
                audioMixer.SetFloat($"Vol_{previousTrack}", volume);
            }
        }

        // Unmute selected.
        audioMixer.GetFloat($"Vol_{selectedTrack}", out volume);
        volume = Mathf.MoveTowards(volume, 0f, transitionSpeed * Time.deltaTime);
        audioMixer.SetFloat($"Vol_{selectedTrack}", volume);
    }

    public void ChangeMusic(int trackIndex)
    {
        // Make sure the last transition was fully completed.
        audioMixer.GetFloat($"Vol_{selectedTrack}", out float volume);
        if (volume != 0f) audioMixer.SetFloat($"Vol_{selectedTrack}", -80f);

        selectedTrack = trackIndex;
    }
}
