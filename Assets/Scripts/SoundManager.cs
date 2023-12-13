using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; } = null;
    AudioSource SoundSource;
    AudioSource MusicSource;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        
    }
    public void PlayMusic(AudioClip _musicClip)
    {
        MusicSource.clip = _musicClip;
        MusicSource.Play();
    }
    public void PlaySound(AudioClip _soundClip)
    {
        SoundSource.PlayOneShot(_soundClip, 1f);
    }
    public void StopMusic()
    {
    MusicSource.Stop();
    }
}
