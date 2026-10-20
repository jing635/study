using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.ShowPanel<GameLobbyPanel>();
        AudioManager.instance.Play("bk2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
