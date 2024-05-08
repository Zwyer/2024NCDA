public class Card
{
    public int CardID;
    public int Cost;
    public Card(int _CardID, int _Cost)
    {
        this.CardID = _CardID;
        this.Cost = _Cost;
    }
}
public class AttackCard : Card
{
    public int ATK;
    public string Effection;
    public AttackCard(int _CardID, int _Cost, int _ATK, string _Effection) : base(_CardID, _Cost)
    {
        this.ATK = _ATK;
        this.Effection = _Effection;
    }
}
public class DefendCard : Card
{
    public int DEF;
    public string Effection;
    public DefendCard(int _CardID, int _Cost, int _DEF, string _Effection) : base(_CardID, _Cost)
    {
        this.DEF = _DEF;
        this.Effection = _Effection;
    }
}

