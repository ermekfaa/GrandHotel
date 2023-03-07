using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using TMPro;
using static Bell;
using UnityEngine.UIElements;

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
        MakeCustomerVisible();
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
            transparent = true;
            StartCoroutine(waitTillVisible());
            // Karakter solma efekti
            //characterRenderer = level1Characters[count].GetComponent<SpriteRenderer>();
            //characterRenderer.color = fadeColor;

            //Instantiate(level1Characters[count],defaultSpawn,Quaternion.identity);
            //characterRenderer.color = Color.Lerp(characterRenderer.color, defaultColor, 1f);

            CharacterCall();

            
            Debug.Log("spawn");
            isCustomer = true;
            //Karakter interaksiyonu

        }

    }

    IEnumerator waitTillVisible()
    {
        
        yield return new WaitForSeconds(2);
    }

    void MakeCustomerVisible()
    {
        if (transparent)
        {

            spriteRenderer.color = Color.Lerp(spriteRenderer.color, defaultColor, Time.deltaTime * 1);
            Debug.Log("transp");
            if ((Mathf.Abs(spriteRenderer.color.a - defaultColor.a) <= 0.01))
            {
                transparent = false;
            }
        }
    }




    /*IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            txt.text += c;
            yield return new WaitForSeconds(0.125f);
        }
    }*/



}
