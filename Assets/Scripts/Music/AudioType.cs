using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AudioType 
{
    [HideInInspector]
    public AudioSource Source;
    public AudioClip Clip;
    public string name;
    [Range(0f,1f)]
    public float volume;
    public bool isLoop;
}
