using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    public Button btnReturn;
    public Button btnBack;
    public Toggle tgMusic;
    public Toggle tgSoundEffect;
    public Scrollbar sbMusic;
    public Scrollbar sbSoundEffect;

    public override void Init()
    {
        btnReturn.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySound("click");

            AudioManager.instance.SaveSettingData();

            UIManager.Instance.HidePanel<SettingPanel>();
            UIManager.Instance.ShowPanel<GameLobbyPanel>();
        });

        btnBack.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySound("click");

            AudioManager.instance.SaveSettingData();

            UIManager.Instance.HidePanel<SettingPanel>();

            SceneManager.LoadScene("LoginScenes");     
        });

       
        tgMusic.onValueChanged.AddListener((isOn) =>
        {
            if (isOn)
            {
                AudioManager.instance.PlayMusic("bk2");
            }
            else
            {
                AudioManager.instance.StopMusic();
                sbMusic.value = 0f;
            }
        });

        
        tgSoundEffect.onValueChanged.AddListener((isOn) =>
        {
            AudioManager.instance.SetSoundVolume(isOn ? sbSoundEffect.value : 0f);
            if(!isOn)
            {
                sbSoundEffect.value = 0f;
            }
        });

        
        sbMusic.onValueChanged.AddListener((value) =>
        {
            AudioManager.instance.SetMusicVolume(value);
            if(value == 0f)
            {
                tgMusic.isOn = false;
            }
            else
            {
                tgMusic.isOn = true;
            }
        });

        
        sbSoundEffect.onValueChanged.AddListener((value) =>
        {
            AudioManager.instance.SetSoundVolume(value);

            if (value == 0f)
            {
                tgSoundEffect.isOn = false;
            }
            else
            {
                tgSoundEffect.isOn = true;
            }

        });
    }

    public override void ShowMe()
    {
        base.ShowMe();

        SettingData settingdata = JsonMgr.Instance.LoadDate<SettingData>("SettingData");

        tgMusic.isOn = settingdata.isOpenMusic;
        tgSoundEffect.isOn = settingdata.isOpenSoundEffect;
        sbMusic.value = settingdata.Musicvolume;
        sbSoundEffect.value = settingdata.SoundEffectvolume;
        
    }
}
