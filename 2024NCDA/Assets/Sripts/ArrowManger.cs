using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro.EditorUtilities;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public Vector2 StartPoint;
    private Vector2 EndPoint;
    private RectTransform arrowTransform;

    private float ArrowLenth;
    private float ArrowTheta;       //½Ç¶È
    private Vector2 ArrowPositon;

    void Start()
    {
        arrowTransform = transform.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        arrowPosition();
    }

    public void SetStartPositon(Vector2 _startPosition)
    {
        StartPoint = _startPosition - new Vector2(960.0f, 540.0f);
    }

    public void arrowPosition()
    {
        EndPoint = Input.mousePosition - new Vector3(960.0f, 540.0f, 0.0f);

        ArrowPositon = new Vector2((EndPoint.x + StartPoint.x) / 2, (EndPoint.y + StartPoint.y) / 2);
        ArrowLenth = Mathf.Sqrt((EndPoint.x - StartPoint.x) * (EndPoint.x - StartPoint.x) + (EndPoint.y - StartPoint.y) * (EndPoint.y - StartPoint.y)) - 10;
        ArrowTheta = Mathf.Atan2(EndPoint.y - StartPoint.y, EndPoint.x - StartPoint.x);

        arrowTransform.localPosition = ArrowPositon;
        arrowTransform.sizeDelta = new Vector2(ArrowLenth, arrowTransform.sizeDelta.y);
        arrowTransform.localEulerAngles = new Vector3(0.0f, 0.0f, ArrowTheta * 180 / Mathf.PI);

        //Debug.Log("END"+EndPoint);
        //Debug.Log("MOS"+Input.mousePosition);
    }

}
