using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class UIManager 
{
    private static UIManager instance = new UIManager();

    public static UIManager Instance => instance;

    private Dictionary<string,BasePanel> panelDic= new Dictionary<string,BasePanel>();

    private Transform canvasTrans;

    private UIManager()
    {
        canvasTrans = GameObject.Find("Canvas").transform;

        GameObject.DontDestroyOnLoad(canvasTrans.gameObject);
    }

    public T ShowPanel<T>() where T:BasePanel
    {
        string panelName = typeof(T).Name;

        if (panelDic.ContainsKey(panelName))
        {
            return panelDic[panelName] as T;
        }

        GameObject panelObject = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + panelName));

        panelObject.transform.SetParent(canvasTrans, false);

        T panel = panelObject.GetComponent<T>();

        panelDic.Add(panelName, panel);

        panel.ShowMe();

        return panel;

    }

    public void HidePanel<T>() where T:BasePanel
    {
        string panelName = typeof(T).Name;

        if (panelDic.ContainsKey(panelName))
        {
            GameObject.Destroy(panelDic[panelName].gameObject);

            panelDic.Remove(panelName);
        }
    }

    public T GetPanel<T>() where T:BasePanel
    {
        string panelName = typeof(T).Name;

        if(panelDic.ContainsKey(panelName))
        {
            return panelDic[panelName] as T;
        }

        return null;
    }



}
