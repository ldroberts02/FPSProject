using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; } = null;
    public AudioSource SoundSource;
    public AudioSource MusicSource;
    public SoundTable soundList;
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
    public void PlaySound(int soundListInt)
    {
        SoundSource.PlayOneShot(soundList.sounds[soundListInt], 1f);
    }
    public void StopMusic()
    {
    MusicSource.Stop();
    }
}
