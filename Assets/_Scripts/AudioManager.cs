using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Referências para o som do laser: https://soundbible.com/1802-Alien-Machine-Gun.html

/* 
Música de fundo:
Voxel Revolution by Kevin MacLeod
Link: https://incompetech.filmmusic.io/song/7017-voxel-revolution
License: https://filmmusic.io/standard-license
*/

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource sfxSource = default;

    [SerializeField]
    private AudioSource ambienceSource = default;

    [SerializeField]
    private AudioClip music = default;

    private static AudioManager _instance;

    void Awake()
    {
        _instance = this;
        if (music)
        {
            ambienceSource.loop = true;
            ambienceSource.clip = music;
            ambienceSource.Play();
        }
    }

    public static void PlaySFX(AudioClip audioClip)
    {
        _instance.sfxSource.PlayOneShot(audioClip);
    }

    public static void SetAmbience(AudioClip audioClip)
    {
        _instance.ambienceSource.Stop();
        _instance.ambienceSource.clip = audioClip;
        _instance.ambienceSource.Play();
    }
}
