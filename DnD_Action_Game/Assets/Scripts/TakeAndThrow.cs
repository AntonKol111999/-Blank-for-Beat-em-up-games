using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAndThrow : MonoBehaviour
{
    [SerializeField] private GameObject PlayerParentObject;
    //public GameObject childObject;
    [SerializeField] float impulse;
    public Rigidbody2D boxRigidbody;

    bool isColliding = false;
    bool Item_Taken = false;

    public Rigidbody2D object1;
    public Transform object2;
    public float impulseForce = 10f;
    float impulseMagnitude = 10.0f; // Значение 10 единиц силы

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
        Debug.Log("Соприкосновение с объектом: " + collision.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
        Debug.Log("Отход от объекта: " + collision.gameObject.name);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isColliding == true)     // Взять объект
        {
            Item_Taken = true;
            Debug.Log("Кнопка E зажата");
            this.transform.SetParent(PlayerParentObject.transform);
            this.GetComponent<Collider2D>().enabled = false;
        }
        if (Input.GetKey(KeyCode.E) && Item_Taken == true)     // Отпустить объект (не работает)
        {
            Debug.Log("Кнопка E зажата (Отпустить)");
            this.transform.SetParent(null);
            this.GetComponent<Collider2D>().enabled = true;
            Item_Taken = false;
        }

        Vector2 direction = (boxRigidbody.position - (Vector2)transform.position).normalized;
        

        if (Input.GetKeyDown(KeyCode.Q))                            // Бросить объект
        {
            Rigidbody2D object1Rigidbody = object1.GetComponent<Rigidbody2D>();
            Rigidbody2D object2Rigidbody = object2.GetComponent<Rigidbody2D>();

            Vector2 direction1 = object2Rigidbody.position - object1Rigidbody.position;
            direction.Normalize();

            Vector2 force = direction1 * impulseMagnitude;

            object1Rigidbody.AddForce(force, ForceMode2D.Impulse);

            /*
            Item_Taken = false;
            isColliding = false;
            Debug.Log("Кнопка Q зажата");
            this.transform.SetParent(null);
            this.GetComponent<Collider2D>().enabled = true;
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            this.GetComponent<Rigidbody2D>().AddForce(direction * impulse, ForceMode2D.Impulse);
            Item_Taken = false;
            */
            //boxRigidbody.AddForce(direction * impulse, ForceMode2D.Impulse);

        }
    }
}
