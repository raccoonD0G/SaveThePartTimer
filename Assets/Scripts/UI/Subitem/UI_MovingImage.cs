using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MovingImage : UI_Base
{
    public override void Init()
    {
        _uiObject = gameObject.GetComponent<RectTransform>();
        _resetPositionX = _uiObject.localPosition.x;
        _endPositionX = _resetPositionX + -4320.0f;
        
    }

    void Start()
    {
        Init();
    }

    RectTransform _uiObject;
    float _speed = -130f;
    float _resetPositionX;
    float _endPositionX;

    void Update()
    {
        Vector3 currentPosition = _uiObject.localPosition;

        currentPosition.x += _speed * Time.deltaTime;

        if (currentPosition.x <= _endPositionX)
        {
            currentPosition.x = _resetPositionX;
        }

        _uiObject.localPosition = currentPosition;
    }
}
