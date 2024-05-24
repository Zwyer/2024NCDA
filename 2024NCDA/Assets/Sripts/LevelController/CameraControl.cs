using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 tarVec;
    void Start()
    {
        tarVec = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != tarVec)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position
                , tarVec, 0.1f);
        }
    }
}
