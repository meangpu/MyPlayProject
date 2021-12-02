using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    // FindObjectOfType<AudioManager>().Play("soundName");

    public Sound[] sounds;
    public static AudioManager instance;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volumn;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = s.mixer;
        }
    }

    private void Start() 
    {
        FindObjectOfType<AudioManager>().Play("BG");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.audioName == name);
        if(s==null)
        {
            return;
        }
        s.source.Play();
    }

    public void PlayWithV(string name, float volumn)
    {
        Sound s = Array.Find(sounds, sound => sound.audioName == name);
        if(s==null)
        {
            return;
        }
        s.source.volume = volumn;
        s.source.Play();
    }

    public void PlayOne(string name, float vol)
    {
        Sound s = Array.Find(sounds, sound => sound.audioName == name);
        if(s==null)
        {
            return;
        }
        s.source.PlayOneShot(s.clip, vol);
    }

    public void PlayAddPitch(string name, float addingValue, bool doPlay=true)
    {
        Sound s = Array.Find(sounds, sound => sound.audioName == name);
        if(s==null)
        {
            return;
        }
        s.pitch += addingValue;
        s.source.pitch = s.pitch;
        if(doPlay)
        {
            s.source.Play();
        }   
        
    }

}
