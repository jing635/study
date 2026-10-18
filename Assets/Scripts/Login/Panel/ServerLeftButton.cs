using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ServerLeftButton : MonoBehaviour
{
    public Button btnself;
    public TextMeshProUGUI txtinfo;

    private int beginIndex;
    private int endIndex;

    // Start is called before the first frame update
    void Start()
    {
        btnself.onClick.AddListener(() =>
        {
            ChooseServerPanel panel = UIManager.Instance.GetPanel<ChooseServerPanel>();
            panel.UpdatePanel(beginIndex,endIndex);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitInfo(int beginIndex , int endIndex)
    {
        this.beginIndex = beginIndex;
        this.endIndex = endIndex;

        txtinfo.text = beginIndex + " - " + endIndex + "区";
    }
}
