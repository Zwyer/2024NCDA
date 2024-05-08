using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadPlayerData : MonoBehaviour
{

    public TextAsset PlayerData;

    public LoadCard LoadCard;
    public int coin;
    public int[] playerCard;

    private void Awake()
    {
        LoadCard.loadCardData();
        loadPlayerData();
    }

    public void savePlayerData()
    {
        string path = Application.dataPath + "/Data/playerdata.csv";

        List<string> PlayerDatas = new List<string>();
        PlayerDatas.Add("coins," + coin);
        //²Ö¿â¿¨ÅÆ±£´æ
        for (int i = 0; i < playerCard.Length; i++)
        {
            if (playerCard[i] != 0)
            {
                PlayerDatas.Add("card," + i + "," + playerCard[i]);
            }
        }
        File.WriteAllLines(path, PlayerDatas);
    }
    public void loadPlayerData()
    {
        playerCard = new int[LoadCard.cardList.Count];

        string[] dataRow = PlayerData.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#")
            {
                continue;
            }
            else if (rowArray[0] == "coins")
            {
                //Load Coin
                coin = int.Parse(rowArray[1]);
            }
            else if (rowArray[0] == "card")
            {
                //Load Card
                int id = int.Parse(rowArray[1]);
                int num = int.Parse(rowArray[2]);
                playerCard[id] = num;
            }
        }
    }
}
