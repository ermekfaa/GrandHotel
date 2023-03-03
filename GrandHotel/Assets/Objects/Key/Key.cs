using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Key : MonoBehaviour
{
    protected Rigidbody2D rb;
    public Vector2 com;
    public bool Awake;

    Vector3 bigsize = new Vector3(1.5f, 1.5f, 1.5f);
    Vector3 normalsize = new Vector3(1, 1, 1);
    Vector3 customerPos = new Vector3(0, 1.5f, 0);



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
        if (Mathf.Abs(gameObject.transform.position.x - customerPos.x) < 0.5 && Mathf.Abs(gameObject.transform.position.y - customerPos.y) < 2.0)
        {
            Debug.Log("destroyed");
            
        }
        else
        {
            Debug.Log("not");
        }
    }

    #region highlight key
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            spriteRenderer.color = new Color(1, 0.85f, 0.85f);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            spriteRenderer.color = new Color(1, 1f, 1f);
        }
    }

    #endregion 

}
