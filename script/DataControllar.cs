using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;

public class DataControllar : MonoBehaviour {


    public static DataControllar instance;

    string path;    //文字滚屏txt地址
    string path2;    //文字滚屏txt地址
    StreamReader sr;//数据流对象
    StreamReader sr2;//数据流对象
    Queue<rollbackEvent> rollback;//用于存储回滚文字的队列
    Queue<triggerEvent> trigger;//用于存储触发文字的队列
    WinnerCondition wc;//存储游戏数据对象

    private void Start()
    {
        InIt();
        getRollBack();
        getTrigger();

    }
    /*
        *初始化操作
        */
    public void InIt()
    {
        path = Application.dataPath + "/RollBack.txt";
        path2 = Application.dataPath + "/Trigger.txt";
        sr = new StreamReader(path, Encoding.Default);
        sr2 = new StreamReader(path2, Encoding.Default);
        rollback = new Queue<rollbackEvent>();
        trigger = new Queue<triggerEvent>();
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
    *获取回滚文字队列
    */
    public Queue<rollbackEvent> getRollBack()
    {

        string result = sr.ReadToEnd();
        string[] group = result.Split('=');
        for (int i = 0; i < group.Length - 1; i++)
        {
            //Debug.Log(group[i]);
            string[] data = group[i].Split('#');
            rollbackEvent rb = new rollbackEvent();
            rb.setId(int.Parse(data[0]));
            rb.setWord(data[1]);
            rb.setWork(float.Parse(data[2]));
            rb.setFamily(float.Parse(data[3]));
            rb.setStatus(float.Parse(data[4]));

            rollback.Enqueue(rb);
        }
        sr.Close();
        return rollback;
    }

    /*
*获取触发文字队列
*/
    public Queue<triggerEvent> getTrigger()
    {
        string result = sr2.ReadToEnd();
        string[] group = result.Split('=');
        for (int i = 0; i < group.Length -1; i++)
        {
            //Debug.Log(group[i]);
            string[] data = group[i].Split('#');
            triggerEvent te = new triggerEvent();
            te.setId(int.Parse(data[0]));
            te.setWord(data[1]);
            te.setWork(float.Parse(data[2]));
            te.setFamily(float.Parse(data[3]));
            te.setStatus(float.Parse(data[4]));

            trigger.Enqueue(te);
        }

        sr2.Close();
        return trigger;
    }


 }

