using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Texts : MonoBehaviour
{
    TextMeshProUGUI txt;
    string script1 = "- Çok uzak yoldan geldim. Elinizdeki en uygun odayý verebilir misiniz?";




    void Start()
    {
        //Text sets your text to say this message
        txt= GetComponent<TextMeshProUGUI>();
        txt.text = "";

        StartCoroutine(PlayText(script1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayText(string story)
    {
        foreach (char c in story)
        {
            txt.text += c;
            yield return new WaitForSeconds(0.125f);
        }
    }
}
