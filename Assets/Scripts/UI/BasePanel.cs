using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePanel : MonoBehaviour
{
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Init();
    }

    public abstract void Init();

    public virtual void ShowMe() { }

    public virtual void HideMe() { }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
