using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Threading;


//�غ�״̬
public enum GameState
{
    gameStart,
    playerDraw,
    playerAction,
    enemyAction
}

public class BattleManager : MonoSingleton<BattleManager>
{
    public static BattleManager Instance;
    public GameObject Canvas;

    //Deck
    //���ε����ͽ����㣬�����˿��ڴ�С
    Vector3 start = new Vector3(-3, 1, 0);
    Vector3 end = new Vector3(3, 1, 0);

    //Card
    public GameObject BattleCardPrefab;


    //HandsCard
    public Transform CardDeckTransform;
    public Transform HnadsCardBlock;


    //Arrow
    public GameObject ArrowPrefab;
    private GameObject arrow;
    public ArrowManager ArrowManager;

    //Battle
    public GameObject Enemy;
    public GameObject Player;
    public HealthControl HealthControl;
    public GameState GameState = GameState.gameStart;
    public UnityEvent phaseChangeEvent = new UnityEvent();
    public LoadPlayerData LoadPlayerData;
    public List<Card> iPlayerDeckList = new List<Card>();
    RaycastHit HitInfo;



    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameStart();
    }

    private void Update()
    {
        RayCheck();
    }


    /// <summary>
    /// ��Ϸ��ʼ����
    /// </summary>
    public void GameStart()
    {
        GameStartLoadDeck();
        ShuffletDeck();


        nextState();
    }
    public void GameStartLoadDeck()
    {
        //�������
        for (int i = 0; i < LoadPlayerData.playerCard.Length; i++)
        {
            //Debug.Log("OKKK?");
            if (LoadPlayerData.playerCard[i] != 0)
            {
                int count = LoadPlayerData.playerCard[i];
                for (int j = 0; j < count; j++)
                {
                    iPlayerDeckList.Add(LoadPlayerData.LoadCard.copyCard(i));
                    //Debug.Log("LOAD");
                }
            }
        }
    }
    public void ShuffletDeck()
    {
        List<Card> shuffletDeck = new List<Card>();
        shuffletDeck = iPlayerDeckList;

        for (int i = 0; i < shuffletDeck.Count; i++)
        {
            int rad = Random.Range(0, shuffletDeck.Count);
            Card temp = shuffletDeck[i];
            shuffletDeck[i] = shuffletDeck[rad];
            shuffletDeck[rad] = temp;
        }
    }
    public void DrawCard(int _number)
    {
        List<Card> drawCard = new List<Card>();
        Transform hand;
        hand = HnadsCardBlock;
        drawCard = iPlayerDeckList;


        for (int i = 0; i < _number; i++)
        {
            GameObject card = Instantiate(BattleCardPrefab, hand);
            //Thread.Sleep(1000);
            //card.transform.SetParent(HnadsCardBlock, false);
            //card.transform.DOMove(CardDeckTransform.position, 2).From();
            card.GetComponent<CardDisplay>().card = drawCard[0];
            drawCard.RemoveAt(0);
        }
    }
    public void DrawCardButton()
    {
        DrawCard(10);
    }


    /// <summary>
    /// ����
    /// </summary>
    /// <param name="_player"></param>
    /// <param name="_Card"></param>
    public void AttackRequst(GameObject _Card)
    {
        //������ͷ
        CreateArrow(_Card.transform, ArrowPrefab);
        arrow.transform.SetParent(Canvas.transform, false);
    }
    public void AttackConfire(GameObject _Card)
    {
        if (HitInfo.collider.gameObject)
        {
            Attack(_Card);
        }
    }
    public void Attack(GameObject _Attacker)
    {
        AttackCard attack = _Attacker.GetComponent<CardDisplay>().card as AttackCard;
        Debug.Log(attack.ATK);
        HealthControl.HealthNumChange(0, attack.ATK);
    }


    /// <summary>
    /// ������ͷ
    /// </summary>
    /// <param name="_statrPosition"></param>
    /// <param name="_prefab"></param>
    public void CreateArrow(Transform _statrPosition, GameObject _prefab)
    {
        arrow = GameObject.Instantiate(_prefab, _statrPosition);
        arrow.GetComponent<ArrowManager>().SetStartPositon(new Vector2(_statrPosition.position.x, _statrPosition.position.y));
    }
    public void DestroyArrow()
    {
        Destroy(arrow);
    }

    /// <summary>
    /// ���߼��Ŀ��
    /// </summary>
    public void RayCheck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //����һ��RaycastHit�ṹ�壬�洢��ײ��Ϣ
        if (Physics.Raycast(ray, out HitInfo))
        {
            //Debug.Log(HitInfo.collider.gameObject.name);
            if (arrow)
            {
                arrow.GetComponent<Image>().color = new Color(1, 0, 0);
            }
        }
        else
        {
            if (arrow)
            {
                arrow.GetComponent<Image>().color = new Color(0, 1, 0);
            }
        }
    }

    /// <summary>
    /// �غ��л�
    /// </summary>
    public void nextState()
    {
        if ((int)GameState == System.Enum.GetNames(GameState.GetType()).Length - 1)
        {
            GameState = GameState.playerDraw;
        }
        else
        {
            GameState += 1;
        }
        phaseChangeEvent.Invoke();
    }
}
