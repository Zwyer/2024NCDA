using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于读取静态数据，不用于存档读取
/// 卡牌信息：CardInfoEachRow 
/// </summary>
public class ReadDataSystem : MonoBehaviour
{
    
    // 卡牌信息
    private TextAsset CardInfo;
    private String[] CardInfoRaw;
    public String[][] CardInfoEachRow;
    
    void Awake()
    {
        //卡牌信息
        CardInfo = Resources.Load<TextAsset>("GameData/CardInfo");
        CardInfoRaw = CardInfo.text.Split('\n');
        CardInfoEachRow = new string[CardInfoRaw.Length][];
        for (int i = 0; i < CardInfoRaw.Length - 1; i++)
        {
            CardInfoEachRow[i] = CardInfoRaw[i].Split(',');
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
