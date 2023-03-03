using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    public delegate void onBellTrigger();
    public static event onBellTrigger BellTriggered;

    public AudioSource source;
    public AudioClip BellSound;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("ding");
        source.PlayOneShot(BellSound);
        BellTriggered();
    }

}
