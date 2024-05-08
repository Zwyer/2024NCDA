using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCard : MonoBehaviour
{
    // Start is called before the first frame update
    
    private int ChildNum,pastChildNum;
    public int tAngle = 10;
    
    public float dis = 7;
    int Lcount = 0, Rcount = 0;
    public bool hasNewCard;//手牌数量发生变化
    void Start()
    {
        pastChildNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ChildNum = transform.childCount;
        if (pastChildNum != ChildNum)
        {
            hasNewCard = true;
            pastChildNum = ChildNum;
        }
        Lcount = 0;
        Rcount = 0;
        if (hasNewCard)
        {
            int midID = ChildNum >> 1;
            for (int i = 0; i < ChildNum; i++)
            {
                
                //手牌为单数时存在中间手牌，双数不存在中间手牌
                //孩子编号为单数时放左侧，双数放右侧
                if ((ChildNum & 1) == 1)
                {
                    if (i == midID)
                    {
                        
                        GetCardPos(0,midID);
                    }
                    else
                    {
                        if (i == midID - Lcount - 1)
                        {
                            GetCardPos(1,midID - Lcount - 1);
                        }
                        else if(i == midID + Rcount + 1)
                        {
                            //Debug.Log(midID + "  " + Lcount + "  " + Rcount);
                            GetCardPos(2,midID + Rcount + 1);
                        }
                    }
                }
                else
                {
                    if ((i & 1) == 0)
                    {
                        GetCardPos(1,midID - Lcount - 1);
                    }
                    else
                    {
                        GetCardPos(2,midID + Rcount);
                    }
                }
            }

            hasNewCard = false;
        }
    }
    
    //pos为0表示中间，1为左侧，2为右侧
    void GetCardPos(int pos,int id)
    {
        GameObject _child = transform.GetChild(id).gameObject;
        float x, y;
        int curAngle;
        if (pos == 0)
        {
            curAngle = 0;
            x = 0;
            y = dis;
        }else if (pos == 1)
        {
            Lcount++;
            curAngle = Lcount * tAngle;
            x = (float)(0-dis * Mathf.Abs(Mathf.Sin(curAngle*Mathf.Deg2Rad)));
            y = (float)(dis * Mathf.Abs(Mathf.Cos(curAngle*Mathf.Deg2Rad)));
        }
        else
        {
            Rcount++;
            curAngle = Rcount * tAngle;
            x = (float)(dis * Mathf.Abs(Mathf.Sin(curAngle*Mathf.Deg2Rad)));
            y = (float)(dis * Mathf.Abs(Mathf.Cos(curAngle*Mathf.Deg2Rad)));
            curAngle = 0 - curAngle;
        }
        
        _child.transform.localPosition = new Vector3(x, y, 0);
        _child.transform.localEulerAngles = new Vector3(0, 0, curAngle);
        _child.GetComponent<SpriteRenderer>().sortingOrder = ChildNum - id;
        
    }
}
