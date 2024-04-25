using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonATK : Cards
{
    // Start is called before the first frame update
    void Start()
    {
        BaseInit(1,1,0,1);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ATK);
    }
}
