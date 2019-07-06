using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;

public class DataControllar : MonoBehaviour {

    public static DataControllar instance;

    string path;    //文字滚屏txt地址
    StreamReader sr;//数据流对象
    List<string> word;//用于存储文字滚屏文字的队列
    WinnerCondition wc;//存储游戏数据对象

    private void Start()
    {
        InIt();
        getData();
    }

    /*
     *初始化操作
     */
    public void InIt()
    {
        path = Application.dataPath + "/test1.txt";
        sr = new StreamReader(path);
        word = new List<string>();
        wc = new WinnerCondition();
    }

    void Awake()
    {
        instance = this;
    }

    /*
    **获取UI目录节点
    */
    public Transform getUIRoot()
    {
        return GameObject.Find("UIRoot").transform;
    }

    /*
    *获取文字滚屏队列
    */
    public List<string> getData()
    {
        string result = sr.ReadToEnd();
        string[] data = result.Split('\n');

        for (int i = 0; i < data.Length; i++)
        {
            //Debug.Log(data[i]);
            word.Add(data[i]);
        }

        return word;
    }



}
