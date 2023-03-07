using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using TMPro;
using static Bell;
using UnityEngine.UIElements;
using static Characters;

public class Characters : MonoBehaviour
{
    public delegate void onCharacterCall();
    public static event onCharacterCall CharacterCall;

    public static bool isCustomer = false;
    Color defaultColor = new Color(1f, 1f, 1f, 1.0f);
    Color fadeColor = new Color(1f,1f,1f,0f);

    Vector3 defaultSpawn = new(0, 1.5f,0);
    public static int count = -1;

    private bool transparent = false;

    SpriteRenderer spriteRenderer;

    public Sprite[] sprites;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = fadeColor;
    }

    private void Update()
    {
        if (isCustomer)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, defaultColor, Time.deltaTime * 1);
            if(defaultColor.a - spriteRenderer.color.a == 0.02)
            {
                spriteRenderer.color = defaultColor;
            }
        }
        else
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, fadeColor, Time.deltaTime * 2);
            if (spriteRenderer.color.a - fadeColor.a == 0.02)
            {
                spriteRenderer.color = fadeColor;
            }
        }
        //MakeCustomerVisible();
    }

    void OnEnable()
    {
        BellTriggered += CallCustomer;
    }

    void OnDisable()
    {
        BellTriggered -= CallCustomer;
    }

    void CallCustomer()
    {
        if (!isCustomer) 
        {
            count += 1;
            spriteRenderer.sprite = sprites[count];

            CharacterCall();

            Debug.Log("spawn");
            isCustomer = true;
            //Karakter interaksiyonu
        }
        
    }

    /*

        void MakeCustomerVisible()
        {
            while (spriteRenderer.color.a != defaultColor.a)
            {

                spriteRenderer.color = Color.Lerp(spriteRenderer.color, defaultColor, Time.deltaTime * 1);
                Debug.Log("transp");
                if ((Mathf.Abs(spriteRenderer.color.a - defaultColor.a) <= 0.01))
                {
                    spriteRenderer.color = defaultColor;
                }
            }

        }

        void MakeCustomerInvisible()
        {
            while (spriteRenderer.color.a != fadeColor.a)
            {

                spriteRenderer.color = Color.Lerp(spriteRenderer.color, fadeColor, Time.deltaTime * 1);
                Debug.Log("transp");
                if ((Mathf.Abs(spriteRenderer.color.a - defaultColor.a) <= 0.01))
                {
                    spriteRenderer.color = fadeColor;
                }
            }
        }

    */


    /*IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            txt.text += c;
            yield return new WaitForSeconds(0.125f);
        }
    }*/



}
