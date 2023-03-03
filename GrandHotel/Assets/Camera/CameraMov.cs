using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CameraMov : MonoBehaviour
{

    private Vector3 TelephoneTable = new Vector3(-20, 0, -10);
    private Vector3 CustomerTable = new Vector3(0, 0, -10);
    private Vector3 KeyPanel = new Vector3(5, 0, -10);

    private float speed = 3f;
    private float deviation_val = 0.01f;
    private bool flagForPhone = false;
    private bool flagForCust = false;
    private bool flagForKey = false;

    // Start is called before the first frame update
    void Update()
    {
        if (LerpComm(TelephoneTable, flagForPhone))
        {
            flagForPhone = false;
        }

        if (LerpComm(CustomerTable, flagForCust))
        {
            flagForCust = false;
        }

        if (LerpComm(KeyPanel, flagForKey))
        {
            flagForKey = false;
        }

    }

    

    void OnEnable()
    {
        EventManager.GoToPhone += CustomertoPhone;
        EventManager.GoToCust += toCustomer;
        EventManager.GoToKey += CustomertoKey;
    }

    void OnDisable()
    {
        EventManager.GoToPhone -= CustomertoPhone;
        EventManager.GoToCust -= toCustomer;
        EventManager.GoToKey -= CustomertoKey;
    }

    void CustomertoPhone()
    {
        flagForPhone = true;
        flagForCust = false;
    }

    void toCustomer()
    {
        flagForPhone = false;
        flagForCust = true;
        flagForKey = false;
    }

    void CustomertoKey()
    {
        flagForCust = false;
        flagForKey = true;
    }


    bool LerpComm(Vector3 destination, bool flag)
    {
        if (flag && Math.Abs(transform.position.x - destination.x) > 0.01)
        {
            transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
            return false;
        }
        else { return true; }


    }




}
