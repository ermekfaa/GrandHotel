using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using TMPro;

public class Characters : MonoBehaviour
{
    bool isCustomer = false;
    Color defaultColor = new Color(1f, 1f, 1f, 1.0f);
    Color fadeColor = new Color(1f,1f,1f,0f);

    Vector3 defaultSpawn = new(0, 1.5f,0);
    private static int count = 0;

    public TextMeshProUGUI dialogue;

    public GameObject[] level1Characters;

    SpriteRenderer characterRenderer;

    

    string story = "- Çok uzak yoldan geldim. Elinizdeki en uygun odayý verebilir misiniz?";


    // Start is called before the first frame update
    void Start()
    {
        
        //StartCoroutine("PlayText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnEnable()
    {
        Bell.BellTriggered += CallCustomer;
    }

    void OnDisable()
    {
        Bell.BellTriggered -= CallCustomer;
    }

    void CallCustomer()
    {
        if (!isCustomer) 
        {
            // Karakter solma efekti
            characterRenderer = level1Characters[count].GetComponent<SpriteRenderer>();
            //characterRenderer.color = fadeColor;

            Instantiate(level1Characters[count],defaultSpawn,Quaternion.identity);
            //characterRenderer.color = Color.Lerp(characterRenderer.color, defaultColor, 1f);           

            count += 1;
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
