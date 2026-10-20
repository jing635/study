using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private SettingData settingData;
    public SettingData SettingData => settingData;

    public AudioType[] AudioTypes;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        
        foreach (AudioType type in AudioTypes)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();

            source.playOnAwake = false;
            source.clip = type.Clip;
            source.loop = type.isLoop;
            source.volume = type.volume;
            type.Source = source;
        }
    }

    //找到指定音乐
    private AudioType Find(string name)
    {
        foreach (AudioType type in AudioTypes)
        {
            if (type.name == name)
            {
                return type;
            }
        }

        
        return null;
    }

    //找到特定的一组音乐
    private List<AudioType> ByCategory(AudioCategory category)
    {
        List<AudioType> list = new List<AudioType>();
        foreach (AudioType type in AudioTypes)
        {
            if (type.category == category)
            {
                list.Add(type);
            }
        }
        return list;
    }

    //关闭所有音乐，在开启指定的音乐
    public void PlayMusic(string name)
    {
        AudioType type = Find(name);
       
        StopMusic();

        type.Source.Play();
    }

    //关闭所有音乐
    public void StopMusic()
    {
        foreach (AudioType type in ByCategory(AudioCategory.Music))
        {
            type.Source.Stop();
        }
    }

    //判断有没有音乐播放
    public bool IsMusicPlaying()
    {
        foreach (AudioType type in ByCategory(AudioCategory.Music))
        {
            if (type.Source.isPlaying)
            {
                return true;
            }
        }
        return false;
    }

    //设置音乐音量
    public void SetMusicVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);

        foreach (AudioType type in ByCategory(AudioCategory.Music))
        {
            type.Source.volume = volume;
        }
    }

    //得到音乐音量
    public float GetMusicVolume()
    {
        List<AudioType> list = ByCategory(AudioCategory.Music);
        return list.Count > 0 ? list[0].Source.volume : 0f;
    }

   //播放音效
    public void PlaySound(string name)
    {
        AudioType type = Find(name);

        type.Source.PlayOneShot(type.Clip);
    }

    //设置音效大小
    public void SetSoundVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);

        foreach (AudioType type in ByCategory(AudioCategory.SoundEffect))
        {
            type.Source.volume = volume;
        }
    }

    //得到音效大小
    public float GetSoundVolume()
    {
        List<AudioType> list = ByCategory(AudioCategory.SoundEffect);
        return list.Count > 0 ? list[0].Source.volume : 0f;
    }

    public void SaveSettingData()
    {
        settingData.Musicvolume = GetMusicVolume();
        if(settingData.Musicvolume != 0f)
        {
            settingData.isOpenMusic = true;
        }
        else
        {
            settingData.isOpenMusic = false;
        }
        settingData.SoundEffectvolume = GetSoundVolume();
        if( settingData.SoundEffectvolume != 0f)
        {
            settingData.isOpenSoundEffect = true;
        }
        else
        {
            settingData.isOpenSoundEffect = false;
        }
        JsonMgr.Instance.SaveDate(settingData, "SettingData");
    }
}