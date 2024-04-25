using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public int ID;
    public int ATK, tATK;//攻击
    public int DEF, tDEF;//防御
    public int PRICE,tPRICE;//花费
    public void BaseInit(int id,int atk,int def,int price)
    {
        ATK = atk;
        DEF = def;
        PRICE = price;
        ID = id;
        
        tATK = 0;
        tDEF = 0;
        tPRICE = 0;
    }
}
