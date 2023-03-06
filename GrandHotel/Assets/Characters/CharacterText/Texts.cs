using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.U2D.Path;

public class Texts : MonoBehaviour
{
    TextMeshProUGUI txt;
    public Texture BoxTexture;
    //string script1 = "- �ok uzak yoldan geldim. Elinizdeki en uygun oday� verebilir misiniz?";
    string[,] scriptList = {{ "Rue: �yi g�nler, uzun bir yolculuktan geldim yol �st�nde kalacak yer olarak buray� buldum. Uygun odan�z var m�d�r?",
                            "Rue: Fiyat� da biraz uygun olursa tabii...","Rue: Te�ekk�rler","Rue: Daha ucuz demi�tim" },

                            {"asdsadsadsa","asdqweqweqeqe","asd","asdd"} };


    public static int[] stopLine = { 1, 0 }; // ka��nc� linedan sonra dursun
    public int[] correctText = { 2, 2 };
    public int[] wrongText = {3,3 };

    private Coroutine displayLineCoroutine; 
    private bool canContinueNextLine = false;
    private bool startText = false;
    public static int index;
    private bool oneLine = true;

    void Start()
    {
        //Text sets your text to say this message
        txt = GetComponent<TextMeshProUGUI>();
        txt.text = string.Empty;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Characters.count + " " + index);
        


        if (startText && Input.GetMouseButtonDown(0))
        {
            if (oneLine) // bug olmas�n diye
            {
                oneLine = false;
            }

            else if (index == stopLine[Characters.count]) // metnin duraca�� yerler
            {
                if (Input.GetMouseButtonDown(0))
                {
                    StopAllCoroutines();
                    txt.text = scriptList[Characters.count, index];
                }
                Debug.Log("dur");
            }
            else if (txt.text == scriptList[Characters.count,index]) 
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                txt.text = scriptList[Characters.count, index];
            }

        }




    }

    void OnEnable()
    {
        Characters.CharacterCall += TextEnable;
        Key.CorrectKey += CorrectKeyText;
        Key.WrongKey += WrongKeyText;
    }

    void OnDisable()
    {
        Characters.CharacterCall -= TextEnable;
        Key.CorrectKey -= CorrectKeyText;
        Key.WrongKey -= WrongKeyText;
    }

    void TextEnable() // ba�latma
    {
        
        index = 0;


        StartCoroutine(PlayText());

        startText = true;

        /*if (displayLineCoroutine != null) {
            StopCoroutine(displayLineCoroutine);
        }
        displayLineCoroutine = StartCoroutine(PlayText(Characters.count));*/

    }

    IEnumerator PlayText() // typewriter effect
    {

        string story = scriptList[Characters.count, index];
        foreach (char c in scriptList[Characters.count, index].ToCharArray())
        {   
            txt.text += c;
            yield return new WaitForSeconds(0.0625f);
            
        }
    }

    void CorrectKeyText()
    {
        StopAllCoroutines();
        index = 1;
        SpesificLine();


        //SpecificLine(correctText[Characters.count]);
        //Karakter transparant olsun
        Characters.isCustomer = false;
    }

    void WrongKeyText()
    {
        StopAllCoroutines();
        index = 2;
        SpesificLine();
        
        
    }


    void NextLine() //2. metine ge�er
    {
        if (index < scriptList.Length - 1)
        {
            index++;
            txt.text = string.Empty;
            StartCoroutine((PlayText()));
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void SpesificLine() //2. metine ge�er
    {
        if (index < scriptList.Length - 1)
        {
            index++;
            txt.text = string.Empty;
            StartCoroutine((PlayText()));
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


}
