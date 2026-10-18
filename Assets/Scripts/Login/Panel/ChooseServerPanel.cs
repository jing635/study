using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ChooseServerPanel : BasePanel
{
    public TextMeshProUGUI txtlast;
    public ScrollRect svLeft;
    public ScrollRect svRight;

    private List<GameObject> itemList = new List<GameObject>();

    public override void Init()
    {
        List<ServerInfo> InfoList = LoginMgr.Instance.ServerData;

        int num = (InfoList.Count + 4) / 5;
        for (int i = 0; i < num; i++)
        {
            GameObject item = Instantiate(Resources.Load<GameObject>("UI/ServerLeftButton"));
            item.transform.SetParent(svLeft.content, false);

            ServerLeftButton serverLeft = item.GetComponent<ServerLeftButton>();

            int beginIndex = i * 5 + 1;
            int endIndex = 5 * i + 5;

            if (endIndex < InfoList.Count)
            {
                endIndex = InfoList.Count;
            }
            serverLeft.InitInfo(beginIndex, endIndex);


        }

    }

    public override void ShowMe()
    {
        base.ShowMe();

        int id = LoginMgr.Instance.LoginData.frontServerID;

        if (id <=0)
        {
            txtlast.text = "无";
        }
        else
        {
            ServerInfo info = LoginMgr.Instance.ServerData[id - 1];

            txtlast.text = info.id + "区" + info.name;
        }
    }

    public void UpdatePanel(int beginIndex,int endIndex)
    {
        foreach (GameObject item in itemList)
        {
            Destroy(item);
        }

        itemList.Clear();

        for (int i = beginIndex; i < endIndex; i++)
        {
            ServerInfo nowInfo = LoginMgr.Instance.ServerData[i-1];

            GameObject serverItem = Instantiate(Resources.Load<GameObject>("UI/ServerRightButton"));

            serverItem.transform.SetParent(svRight.content.transform, false);

            ServerRightButton rightItem = serverItem.GetComponent<ServerRightButton>();

            rightItem.InitInfo(nowInfo);

            itemList.Add(serverItem);
        }

    }
}
