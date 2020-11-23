using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClicksContoller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    private float minlongTime;
    [SerializeField]
    private float maxdcTime;
    [SerializeField]
    private float dcResetTime;
    [SerializeField] private UnityEvent OnLongClickStart;
    [SerializeField] private UnityEvent OnLongClickEnd;
    [SerializeField] private UnityEvent OnDoubleClick;

    private float lctimer = 0;
    private float dctimer = 0;
    private int clicks = 0;

    private bool longclick = false;
    private bool isThisClicked = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit)
            {
                if (hit.collider.gameObject.name == gameObject.name)
                {
                    isThisClicked = true;
                    clicks++;
                }
            }


        }
        else if (Input.GetMouseButton(0) && isThisClicked)
        {
            if (!longclick) 
                lctimer += Time.deltaTime;
            if (lctimer >= minlongTime)
            {
                isThisClicked = false;
                longclick = true;
                lctimer = 0;
                clicks = 0;
                LongClickStart();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (longclick)
            {
                LongClickEnd();
                longclick = false;
            }
        }
        if (clicks == 1)
            dctimer += Time.deltaTime;
        else if (clicks == 2)
        {
            Debug.Log(dctimer);
            if (dctimer <= maxdcTime)
            {
                DoubleClick();
            }
            dctimer = 0;
            clicks = 0;
        }
        if (dctimer >= dcResetTime)
        {
            Debug.Log("RESET");
            dctimer = 0;
            clicks = 0;
        }
    }
    private void DoubleClick ()
    {
        OnDoubleClick?.Invoke();
        Debug.Log("dc");
    }
    private void LongClickStart()
    {

        OnLongClickStart?.Invoke();
        Debug.Log("lc start");
    }
    private void LongClickEnd()
    {
        OnLongClickEnd?.Invoke();
        Debug.Log("lc end");
    }

}
