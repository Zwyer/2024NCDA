using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Image AttackImage;
    public Sprite[] AttackImages;

    public TextMeshProUGUI Cost;
    public TextMeshProUGUI AttackNum;
    public TextMeshProUGUI DefendNum;

    public TextMeshProUGUI Effection;


    public Card card;

    void Start()
    {
        DisplayCard();
    }

    public void DisplayCard()
    {
        Cost.text = card.Cost.ToString();
        if (card is AttackCard)
        {
            var ACard = card as AttackCard;
            Cost.text = ACard.Cost.ToString();
            Effection.text = ACard.Effection;
            AttackImage.sprite = AttackImages[0];
        }
        else if (card is DefendCard)
        {
            var DCard = card as DefendCard;
            Cost.text = DCard.Cost.ToString();
            Effection.text = DCard.Effection;
            AttackImage.sprite = AttackImages[1];
        }
    }
}
