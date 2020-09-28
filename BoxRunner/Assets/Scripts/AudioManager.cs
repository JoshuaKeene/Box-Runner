using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager GlobalSFXManager;
    [Header("AudioClips")]
    #region AudioClips
    public AudioClip MainMusic;
    public AudioClip OnHoverClick;
    public AudioClip OnPressClick;
    public AudioClip GameOver;
    public AudioClip Pickup;
    #endregion

    void Start()
    {
        GlobalSFXManager = this;

        DontDestroyOnLoad(transform.gameObject);
    }

    public IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = 0.2f;

        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.volume = 1f;
    }
}
