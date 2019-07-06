using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerCondition{

    private bool chooseWay;//关卡选择方向
    private int RoadId;//道路ID
    private float work;//事业值
    private float family;//家庭值
    private float status;//地位值
    private float iniHeart;//已获得初心

    public float getWork()
    {
        return work;
    }
    public float getFamily()
    {
        return family;
    }
    public float getStatus()
    {
        return status;
    }
    public void setWork(float value)
    {
        work = value;
    }
    public void setFamily(float value)
    {
        family = value;
    }
    public void setStatus(float value)
    {
        status = value;
    }

    public bool getChooseWay()
    {
        return chooseWay;
    }
    public void setChooseWay(bool choose)
    {
        chooseWay = choose;
    }

    public int getRoadId()
    {
        return RoadId;
    }
    public void setRoadId(int id)
    {
        RoadId = id;
    }

    public float getIniHeart()
    {
        return iniHeart;
    }

    public void setiniHeart(float value)
    {
        iniHeart += value;
    }
}
