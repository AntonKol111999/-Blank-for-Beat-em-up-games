using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 5f; // �������� ��������

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // ��������� �������� ��� "Horizontal"
        float verticalInput = Input.GetAxis("Vertical"); // ��������� �������� ��� "Vertical"

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput); // ����������� ����������� ��������

        Rigidbody2D rb = GetComponent<Rigidbody2D>(); // ��������� Rigidbody2D
        rb.AddForce(movementDirection * speed * Time.deltaTime); // ���������� ���� � Rigidbody2D
    }
}
