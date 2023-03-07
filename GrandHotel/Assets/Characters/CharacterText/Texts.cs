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
    string[,] scriptList = {{ "Ýyi günler, uzun bir yolculuktan geldim yol üstünde kalacak yer olarak burayý buldum. Uygun odanýz var mýdýr?",
                            "Fiyatý da biraz uygun olursa tabii...","Teþekkürler","Daha ucuz demiþtim" },

                            {"Merhaba, adým Iyoko gelmeden önce kayýt yaptýrmýþtým","7 numara olmasý lazým","Teþekkürler","Yanlýþ anahtarý verdiniz sanýrým."},

                            {"a","b","c","d" },

                            {"q","w","e","r" },

                            {"a","s","d","f" },
                            };


    public static int[] stopLine = { 1, 1, 1, 1, 1}; // kaçýncý linedan sonra dursun
    public int[] correctText = { 2, 2, 2, 2, 2 }; // doðru anahtar texti
    public int[] wrongText = {3, 3, 3, 3, 3 }; // yanlýþ anahtar texti

    private Coroutine displayLineCoroutine; 
    private bool canContinueNextLine = false;
    private bool startText = false;
    public static int index;
    private bool oneLine = true;

    void Start()
    {
        //Text sets your text to say this message
        txt = GetComponent<TextMeshProUGUI>(); 
        txt.text = string.Empty; // texti boþ yapar
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Characters.count + " " + index);
            
        // 0 3
        
        if (Characters.isCustomer && Input.GetMouseButtonDown(0)) // müþteri geldi mi diye bakar
        {
            if (oneLine) // bug olmasýn diye
            {
                oneLine = false;
            }

            else if (index >= stopLine[Characters.count]) // metnin duracaðý yerler
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
        txt.text = "";
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
        oneLine = true;
        startText = false;
        Characters.isCustomer = false;

        //SpecificLine(correctText[Characters.count]);
        //Karakter transparant olsun

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
