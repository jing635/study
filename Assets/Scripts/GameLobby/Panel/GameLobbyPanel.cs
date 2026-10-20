using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLobbyPanel : BasePanel
{
    public Button btnDuelArena;
    public Button btncharacter;
    public Button btnSecretScroll;
    public Button btnSummoning;
    public Button btnNinJaTools;
    public Button btnLevel;
    public Button btnSetting;
    public override void Init()
    {
        btnDuelArena.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySound("click");
            //转到决斗场场景
        });

        btncharacter.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySound("click");
            //换成角色面板
        });

        btnSecretScroll.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySound("click");
            //换成密卷面板
        });

        btnSummoning.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySound("click");
            //换成通灵面板
        });

        btnNinJaTools.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySound("click");
            //换成忍具面板
        });

        btnLevel.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySound("click");
            //换成关卡面板
        });

        btnSetting.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySound("click");
            UIManager.Instance.HidePanel<GameLobbyPanel>();
            //换成设置面板
            UIManager.Instance.ShowPanel<SettingPanel>();
        });
       
    }

    
}
