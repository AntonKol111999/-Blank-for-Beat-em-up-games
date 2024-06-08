using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private GameObject heldObject; // Ссылка на текущий удерживаемый объект

    void Update()
    {
        // Логика захвата (замените на ваш предпочтительный метод ввода)
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpObject();
        }

        // Логика броска (замените на ваш предпочтительный метод ввода)
        if (Input.GetKeyDown(KeyCode.Q) && heldObject != null)
        {
            ThrowObject();
        }
    }

    void PickUpObject()
    {
        // Raycast для проверки объекта перед игроком
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x);

        if (hit.collider != null && hit.collider.gameObject.tag == "Item")
        {
            heldObject = hit.collider.gameObject;
            heldObject.transform.parent = transform; // Сделать объект дочерним игроку

            // Дополнительно: отключить физическое моделирование при удержании (предотвращает дрожание)
            heldObject.GetComponent<Rigidbody2D>().simulated = false;
        }
    }

    void ThrowObject()
    {
        // Получить направление броска на основе направления игрока
        Vector2 throwDirection = Vector2.right * transform.localScale.x;

        // Приложить силу в направлении броска
        heldObject.GetComponent<Rigidbody2D>().AddForce(throwDirection * throwForce);

        // Отсоединить объект от игрока и снова включить физику
        heldObject.transform.parent = null;
        heldObject.GetComponent<Rigidbody2D>().simulated = true;

        heldObject = null; // Очистить ссылку на удерживаемый объект
    }

    // Публичная переменная (регулируется в инспекторе)
    public float throwForce = 10.0f;
}
