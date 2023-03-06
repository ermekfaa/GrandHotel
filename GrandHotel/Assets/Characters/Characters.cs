using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using TMPro;
using static Bell;

public class Characters : MonoBehaviour
{
    public delegate void onCharacterCall();
    public static event onCharacterCall CharacterCall;

    bool isCustomer = false;
    Color defaultColor = new Color(1f, 1f, 1f, 1.0f);
    Color fadeColor = new Color(1f,1f,1f,0f);

    Vector3 defaultSpawn = new(0, 1.5f,0);
    public static int count = -1;


    SpriteRenderer characterRenderer;

    public Sprite[] sprites;


    private void Start()
    {
        characterRenderer = GetComponent<SpriteRenderer>();
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
            characterRenderer.sprite = sprites[count];
            //characterRenderer.color = Color.Lerp(defaultColor, fadeColor, Time.deltaTime * 1f);

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

    /*IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            txt.text += c;
            yield return new WaitForSeconds(0.125f);
        }
    }*/



}
