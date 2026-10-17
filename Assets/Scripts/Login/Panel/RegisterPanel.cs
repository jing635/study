using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
    public Button cancelButton;
    public Button sureButton;

    public TMP_InputField userName;
    public TMP_InputField passWord;

    public override void Init()
    {
        cancelButton.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<RegisterPanel>();
            UIManager.Instance.ShowPanel<LoginPanel>();

                       
        });

        sureButton.onClick.AddListener(() =>
        {
            if (userName.text.Length < 7 || passWord.text.Length < 7)
            {
               TipPanel panel = UIManager.Instance.ShowPanel<TipPanel>();
                panel.ChangeInfo("账号和密码必须大于6位数");

                return;

            }
            
            if (LoginMgr.Instance.RegisterUser(userName.text, passWord.text))
            {
                LoginPanel panel = UIManager.Instance.ShowPanel<LoginPanel>();

                panel.SaveInfo(userName.text, passWord.text);

                UIManager.Instance.HidePanel<RegisterPanel>();
            }
            else
            {
                TipPanel panel = UIManager.Instance.ShowPanel<TipPanel>();
                panel.ChangeInfo("用户已存在");

                userName.text = "";
                passWord.text = "";
            }
            

            
        });


    }

   

    
}
