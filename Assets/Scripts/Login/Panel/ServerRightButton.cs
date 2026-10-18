using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ServerRightButton : MonoBehaviour
{
    public Button btnself;
    public TextMeshProUGUI txtServer;
    public TextMeshProUGUI txtState;
    public ServerInfo nowServerInfo;

    void Start()
    {
        btnself.onClick.AddListener(() =>
        {
            LoginMgr.Instance.LoginData.frontServerID = nowServerInfo.id;

            UIManager.Instance.HidePanel<ChooseServerPanel>();
            UIManager.Instance.ShowPanel<ServerPanel>();
        });
        
    }

    public void InitInfo(ServerInfo info)
    {
        nowServerInfo = info;

        txtServer.text = info.id + "区   " + info.name ;

        switch (info.state)
        {
            case 0:
                txtState.text = "拥挤";
                break;
            case 1:
                txtState.text = "流畅";
                break;
        }


    }
}
