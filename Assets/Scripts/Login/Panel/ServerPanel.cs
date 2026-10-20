using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ServerPanel : BasePanel
{
    public TextMeshProUGUI serverName;

    public Button sureButton;

    public Button backButton;

    public Button changeButton;

    public override void Init()
    {
        sureButton.onClick.AddListener(()=>
        {
            UIManager.Instance.HidePanel<ServerPanel>();

            LoginMgr.Instance.SaveLoginData();

            AudioManager.instance.StopMusic();

            SceneManager.LoadScene("GameLobbyScene");

            

            
        });

        backButton.onClick.AddListener(() =>
        {
            if (LoginMgr.Instance.LoginData.autoLogin)
            {
                LoginMgr.Instance.LoginData.autoLogin = false;
            }
            UIManager.Instance.HidePanel<ServerPanel>();
            UIManager.Instance.ShowPanel<LoginPanel>();
        });

        changeButton.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<ChooseServerPanel>();
            UIManager.Instance.HidePanel<ServerPanel>();


        });


    }

    public override void ShowMe()
    {
        base.ShowMe();

        int id = LoginMgr.Instance.LoginData.frontServerID;

        if(id <= 0)
        {
            serverName.text = "无";
        }
        else
        {
            ServerInfo info = LoginMgr.Instance.ServerData[id - 1];

            serverName.text = info.id + "区" + info.name;
        }

    }
}
