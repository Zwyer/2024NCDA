using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool hasFinishCurLv;
    public static int curLv;
    private CameraControl CC;
    private Vector3 baseVec;
    void Start()
    {
        hasFinishCurLv = false;
        curLv = 0;
        CC = gameObject.GetComponent<CameraControl>();
        baseVec = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasFinishCurLv)
        {
            curLv++;
            hasFinishCurLv = false;
            GenerateNextLevel();
            CC.tarVec = new Vector3(baseVec.x,baseVec.y,-10);
        }
    }

    void GenerateNextLevel()
    {
        int levelChoosen = Random.Range(1, 4);
        baseVec = new Vector3(baseVec.x + 3, this.baseVec.y, baseVec.z);
        Vector3[] points = new Vector3[levelChoosen];
        if (levelChoosen == 1)
        {
            points[0] = new Vector3(baseVec.x, baseVec.y, baseVec.z);
        }
        else if (levelChoosen == 2)
        {
            points[0] = new Vector3(baseVec.x, baseVec.y + 1.5f, baseVec.z);
            points[1] = new Vector3(baseVec.x, baseVec.y - 1.5f, baseVec.z);
            
        }
        else
        {
            points[0] = new Vector3(baseVec.x, baseVec.y + 3, baseVec.z);
            points[1] = new Vector3(baseVec.x, baseVec.y, baseVec.z);
            points[2] = new Vector3(baseVec.x, baseVec.y - 3, baseVec.z);
        }

        for (int i = 0; i < levelChoosen; i++)
        {
            GameObject t = Instantiate(Resources.Load<GameObject>("Perfabe/Node"), points[i], Quaternion.identity);
            Node nn = t.GetComponent<Node>();
            nn.Lv = curLv;
            nn.ID = i;
            nn.Type = levelChoosen;
        }
    }
}
