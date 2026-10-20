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
            UIManager.Instance.HidePanel<SettingPanel>();
            UIManager.Instance.ShowPanel<GameLobbyPanel>();
        });

        btnBack.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("LoginScene");
        });

        tgMusic.onValueChanged.AddListener((value) =>
        {
            //设置音乐
            AudioManager.instance.Stop("bk2");
        });

        tgSoundEffect.onValueChanged.AddListener((value) =>
        {
            //设置音效
        });

        sbMusic.onValueChanged.AddListener((value) =>
        {
            //设置音乐
        });

        sbSoundEffect.onValueChanged.AddListener((value) =>
        {
            //设置音效
        });
    }

   
}
