using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public AudioType[] AudioTypes;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        foreach(AudioType type in AudioTypes)
        {
            type.Source = gameObject.AddComponent<AudioSource>();

            
            type.Source.name = type.name;
            type.Source.volume = type.volume;
            type.Source.clip = type.Clip;
            type.Source.loop = type.isLoop;

        }
    }

    public void Play(string name)
    {
        foreach (AudioType type in AudioTypes)
        {
            if(type.name == name)
            {
                type.Source.Play();
                return;
            }
        }
    }

    public void Stop(string name)
    {
        foreach (AudioType type in AudioTypes)
        {
            if (type.name == name)
            {
                type.Source.Stop();
                return;
            }
        }
    }

    
}
