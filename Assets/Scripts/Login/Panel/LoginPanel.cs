using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    public Button registerbutton;
    public Button loginbutton;

    public TMP_InputField username;
    public TMP_InputField password;

    public Toggle rememberpw;
    public Toggle autoLogin;

    public override void Init()
    {
        registerbutton.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<RegisterPanel>();

            UIManager.Instance.HidePanel<LoginPanel>();
        });

        loginbutton.onClick.AddListener(() =>
        {
            if (username.text.Length < 7 || password.text.Length < 7)
            {
                TipPanel panel = UIManager.Instance.ShowPanel<TipPanel>();
                panel.ChangeInfo("账号和密码必须大于6位数");

                return;

            }

            if (LoginMgr.Instance.CheckInfo(username.text, password.text))
            {
                LoginMgr.Instance.LoginData.UserName = username.text;
                LoginMgr.Instance.LoginData.Password = password.text;
                LoginMgr.Instance.LoginData.autoLogin = autoLogin.isOn;
                LoginMgr.Instance.LoginData.rememberPw = rememberpw.isOn;
                LoginMgr.Instance.SavaLoginData();

                UIManager.Instance.HidePanel<LoginPanel>();
            }

            else
            {
                TipPanel panel = UIManager.Instance.ShowPanel<TipPanel>();
                panel.ChangeInfo("用户不存在");

            }

        });

        rememberpw.onValueChanged.AddListener((isOn) =>
        {
            if (!isOn)
            {
                autoLogin.isOn = false;
            }
        });

        autoLogin.onValueChanged.AddListener((isOn) =>
        {
            if (isOn)
            {
                rememberpw.isOn = true;
            }


        });

    }






    public override void ShowMe()
    {
        base.ShowMe();

        LoginData loginData = LoginMgr.Instance.LoginData;

        rememberpw.isOn = loginData.rememberPw;
        autoLogin.isOn = loginData.autoLogin;

        username.text = loginData.UserName;
       
        if (rememberpw.isOn)
        {
            password.text = loginData.Password;
        }
    }

    public void SaveInfo(string userName, string passWord)
    {
        username.text = userName;
        password.text = passWord;
    }

    
}
