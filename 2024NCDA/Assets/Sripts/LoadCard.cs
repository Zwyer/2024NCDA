using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCard : MonoBehaviour
{
    public TextAsset cardData;
    public List<Card> cardList = new List<Card>();



    public void loadCardData()
    {
        string[] Qdata = cardData.text.Split('\n');
        foreach (var row in Qdata)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#")
            {
                continue;
            }
            else if (rowArray[0] == "AttackCard")
            {
                int id = int.Parse(rowArray[1]);
                int Cost = int.Parse(rowArray[2]);
                int ATK = int.Parse(rowArray[3]);
                string Effection = rowArray[4];
                AttackCard AttackCard = new AttackCard(id, Cost, ATK, Effection);
                cardList.Add(AttackCard);
                //Debug.Log("Aok");
            }
            else if (rowArray[0] == "DefendCard")
            {
                int id = int.Parse(rowArray[1]);
                int Cost = int.Parse(rowArray[2]);
                int DEF = int.Parse(rowArray[3]);
                string Effection = rowArray[4];
                DefendCard DefendCard = new DefendCard(id, Cost, DEF, Effection);
                cardList.Add(DefendCard);
                //Debug.Log("Dok");
            }
        }
    }
    public Card copyCard(int _id)
    {
        Card copyCard = new Card(_id, cardList[_id].Cost);
        if (cardList[_id] is AttackCard)
        {
            var copyAttackCard = cardList[_id] as AttackCard;
            copyCard = new AttackCard(_id, copyAttackCard.Cost, copyAttackCard.ATK, copyAttackCard.Effection);
        }
        else if (cardList[_id] is DefendCard)
        {
            var copyDefendCard = cardList[_id] as DefendCard;
            copyCard = new DefendCard(_id, copyDefendCard.Cost, copyDefendCard.DEF, copyDefendCard.Effection);
        }
        return copyCard;
    }
}
