using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TipPanel : BasePanel
{
    public Button SureButton;

    public TextMeshProUGUI TipText;


    public override void Init()
    {
        SureButton.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<TipPanel>();

        });
            
    }

    public void ChangeInfo(string info)
    {
        TipText.text = info;
    }

   
}
