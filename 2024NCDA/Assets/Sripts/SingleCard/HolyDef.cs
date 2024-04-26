using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyDef : Cards
{
    // Start is called before the first frame update
    void Start()
    {
        BaseInit(3,2,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(describeText + "ATK= " + ATK);
    }
}
