using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject AniCircle;
    private Animator CircleAni;
    public int ID,Lv,Type;
    private SpriteRenderer sr;
    
    void Start()
    {
        AniCircle = transform.Find("AniCircle").gameObject;
        CircleAni = AniCircle.GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Lv != LevelControl.curLv)
        {
            sr.color = new Color(0.3f,0.3f,0.3f,0.8f);
        }
    }

    public void OnMouseEnter()
    {
        if (Lv == LevelControl.curLv)
        {
            CircleAni.SetBool("isIn",true);
            sr.color = Color.grey;
        }
    }

    public void OnMouseDown()
    {
        if (Lv == LevelControl.curLv)
        {
            Debug.Log("IntoThisLv,ID="+ID+" LV="+Lv+" Type="+Type);
            //如果完成了
            LevelControl.hasFinishCurLv = true;
        }
    }

    public void OnMouseExit()
    {
        CircleAni.SetBool("isIn",false);
        sr.color = Color.white;
    }
}
