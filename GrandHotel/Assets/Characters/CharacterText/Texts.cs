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
    //string script1 = "- Çok uzak yoldan geldim. Elinizdeki en uygun odayý verebilir misiniz?";
    string[,] scriptList = {{ "Rue: Ýyi günler, uzun bir yolculuktan geldim yol üstünde kalacak yer olarak burayý buldum. Uygun odanýz var mýdýr?",
                            "Rue: Fiyatý da biraz uygun olursa tabii...","Rue: Teþekkürler","Rue: Daha ucuz demiþtim" },

                            {"asdsadsadsa","asdqweqweqeqe","asd","asdd"} };


    public static int[] stopLine = { 1, 0 }; // kaçýncý linedan sonra dursun
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
            if (oneLine) // bug olmasýn diye
            {
                oneLine = false;
            }

            else if (index == stopLine[Characters.count]) // metnin duracaðý yerler
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

    void TextEnable() // baþlatma
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


    void NextLine() //2. metine geçer
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

    void SpesificLine() //2. metine geçer
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
