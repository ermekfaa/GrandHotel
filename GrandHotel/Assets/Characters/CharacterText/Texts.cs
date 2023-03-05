using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Texts : MonoBehaviour
{
    TextMeshProUGUI txt;
    public Texture BoxTexture;
    //string script1 = "- Çok uzak yoldan geldim. Elinizdeki en uygun odayý verebilir misiniz?";
    string[] scriptList = { "- Çok uzak yoldan geldim. Elinizdeki en uygun odayý verebilir misiniz?" };


    void Start()
    {
        //Text sets your text to say this message
        txt = GetComponent<TextMeshProUGUI>();
        txt.text = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        



    }

    void OnEnable()
    {
        Characters.CharacterCall += TextEnable;
    }

    void TextEnable()
    {
        Debug.Log(Characters.count);
        StartCoroutine(PlayText(Characters.count));
    }

    


    IEnumerator PlayText(int count)
    {
        string story = scriptList[Characters.count];
        foreach (char c in story)
        {   
            txt.text += c;
            yield return new WaitForSeconds(0.0625f);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                for (int i = 0;i < count; i++)
                {
                    txt.text += c;
                }
                
            }


        }
    }
}
