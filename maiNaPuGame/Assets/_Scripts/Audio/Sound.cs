using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    // FindObjectOfType<AudioManager>().Play("soundName");
    public string audioName;
    public AudioClip clip;
    [Range(0, 1)]
    public float volumn;
    [Range(0.1f, 3f)]
    public float pitch = 1;
    public AudioMixerGroup mixer;
    public bool loop;
    [HideInInspector]
    public AudioSource source;

}
