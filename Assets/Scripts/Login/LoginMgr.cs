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


    private LoginMgr()
    {
        loginData = JsonMgr.Instance.LoadDate<LoginData>("LoginData");

        registerData = JsonMgr.Instance.LoadDate<RegisterData>("RegisterData");
    }

    public void SavaLoginData()
    {
        JsonMgr.Instance.SaveDate(loginData, "LoginData");
    }

    public void SavaRegisterData()
    {
        JsonMgr.Instance.SaveDate(registerData, "RegisterData");
    }

    public bool RegisterUser(string username, string password)
    {
        if(registerData.registerInfos.ContainsKey(username))
        {
            return false;
        }
        registerData.registerInfos.Add(username, password);

        SavaRegisterData();

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
