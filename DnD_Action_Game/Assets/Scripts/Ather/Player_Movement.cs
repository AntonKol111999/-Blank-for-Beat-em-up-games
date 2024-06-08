using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 5f; // Скорость движения

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Получение значения оси "Horizontal"
        float verticalInput = Input.GetAxis("Vertical"); // Получение значения оси "Vertical"

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput); // Определение направления движения

        Rigidbody2D rb = GetComponent<Rigidbody2D>(); // Получение Rigidbody2D
        rb.AddForce(movementDirection * speed * Time.deltaTime); // Применение силы к Rigidbody2D
    }
}
