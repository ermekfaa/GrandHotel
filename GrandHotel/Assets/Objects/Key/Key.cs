using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Key : MonoBehaviour
{
    public delegate void onKey();
    public static event onKey CorrectKey;
    public static event onKey WrongKey;

    protected Rigidbody2D rb;
    public Vector2 com;
    public bool Awake;

    Vector3 bigsize = new Vector3(1.5f, 1.5f, 1.5f);
    Vector3 normalsize = new Vector3(1, 1, 1);
    Vector3 customerPos = new Vector3(0, 1.5f, 0);

    private bool isIn = false;

    string[] keyToGive = { "101", "102", "103", "104", "105" };



    Vector3 startPoint;

    Vector3 mousePositionOffset;

    bool isDragging = false;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        startPoint = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {


        if (!isDragging)
        {
            transform.position = Vector3.Lerp(transform.position, startPoint, 2 * Time.deltaTime);
        }


        
    }



    private Vector3 GetMouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseEnter()
    {
        transform.localScale = bigsize;
    }

    private void OnMouseExit()
    {
        transform.localScale = normalsize;

        
        
    }

    private void OnMouseDown()
    {
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mousePositionOffset;
        transform.localScale = bigsize;
        isDragging = true;
        transform.rotation = Quaternion.Lerp (transform.rotation, (Quaternion.Euler(transform.rotation.x,transform.rotation.y,0)), Time.deltaTime * 5);
    }

    private void OnMouseUp()
    {
        isDragging = false;
        


        if (Texts.index >= Texts.stopLine[Characters.count] && Characters.isCustomer)
        {
            if (gameObject.name == "key" + keyToGive[Characters.count] ) // hangi anahtar? istedikleri
            {
                Debug.Log("asd");
                gameObject.SetActive(false);

                CorrectKey();
                Characters.isCustomer = false;
                // NEXTLINE
            }
            else
            {
                WrongKey();
            }
        }







    }

    #region highlight key
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            isIn = true;
            spriteRenderer.color = new Color(1, 0.75f, 0.75f);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            isIn = false;
            spriteRenderer.color = new Color(1, 1f, 1f);
        }
    }

    #endregion 




}
