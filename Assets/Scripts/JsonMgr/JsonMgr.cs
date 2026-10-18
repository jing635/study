using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonMgr 
{
    private static JsonMgr instance = new JsonMgr();

    public static JsonMgr Instance => instance;

    private JsonMgr() { }

    public void SaveDate(object date,string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".json";

        string Jsonstr = JsonMapper.ToJson(date);

        File.WriteAllText(path, Jsonstr);
    }

    public T LoadDate<T>(string fileName) where T:new()
    {
        string path = Application.streamingAssetsPath + "/" + fileName + ".json";

        if(!File.Exists(path))
        {
            path = Application.persistentDataPath + "/" + fileName + ".json";
        }

        if (!File.Exists(path))
        {
            return new T();
        }

        string JsonStr = File.ReadAllText(path);

        T date = JsonMapper.ToObject<T>(JsonStr);

        return date;
        

    }
}
