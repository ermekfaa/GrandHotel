using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction GoToPhone;
    public static event ClickAction GoToCust;
    public static event ClickAction GoToKey;

    private bool Left_Button = true;
    private bool Right_Button = true;

    private int order;

    void Start()
    {
        order = 1;
    }

    void OnGUI()
    {
        //
        //Phone'a git Phone ve Key pressed true
        if (Left_Button)
            if (GUI.Button(new Rect(5, Screen.height / 2 - 50, 30, 100), "Click"))
            {
                if (order == 1)
                {
                    GoToPhone();
                    Left_Button = false;
                    Right_Button = true;
                    order -= 1;
                }
                if (order == 2)
                {
                    GoToCust();
                    Left_Button = true;
                    Right_Button = true;
                    order -= 1;
                }


            }

        if (Right_Button)
            if (GUI.Button(new Rect(Screen.width - 35, Screen.height / 2 - 50, 30, 100), "Click"))
            {
                if (order == 1)
                {
                    GoToKey();
                    Left_Button = true;
                    Right_Button = false;
                    order += 1;
                }
                if (order == 0)
                {
                    GoToCust();
                    Right_Button = true;
                    Left_Button = true;
                    order += 1;
                }

            }

    }

}
