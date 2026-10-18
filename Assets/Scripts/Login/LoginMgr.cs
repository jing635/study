using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LoginMgr 
{
    private static LoginMgr instance = new LoginMgr();

    public static LoginMgr Instance => instance;

    private LoginData loginData;

    public LoginData LoginData => loginData;

    private RegisterData registerData;
    public RegisterData RegisterData => registerData;

    private List<ServerInfo> serverInfo;
    public List<ServerInfo> ServerData => serverInfo;


    private LoginMgr()
    {
        loginData = JsonMgr.Instance.LoadDate<LoginData>("LoginData");

        registerData = JsonMgr.Instance.LoadDate<RegisterData>("RegisterData");

        serverInfo = JsonMgr.Instance.LoadDate<List<ServerInfo>>("ServerInfo");
    }

    public void SaveLoginData()
    {
        JsonMgr.Instance.SaveDate(loginData, "LoginData");
    }

    public void SaveRegisterData()
    {
        JsonMgr.Instance.SaveDate(registerData, "RegisterData");
    }

    public void ClearLoginData()
    {
        loginData.frontServerID = 0;
        loginData.rememberPw = false;
        loginData.autoLogin = false;
    }

    public bool RegisterUser(string username, string password)
    {
        if(registerData.registerInfos.ContainsKey(username))
        {
            return false;
        }
        registerData.registerInfos.Add(username, password);

        SaveRegisterData();

        return true;
    }

    public bool CheckInfo(string username, string password) 
    {
        if(registerData.registerInfos.ContainsKey(username))
        {
            if(registerData.registerInfos[username] == password)
            {
                return true;
            }
        }

        return false;
    }
}
