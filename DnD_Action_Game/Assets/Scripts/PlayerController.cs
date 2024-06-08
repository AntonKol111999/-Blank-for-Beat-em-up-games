using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private GameObject heldObject; // ������ �� ������� ������������ ������

    void Update()
    {
        // ������ ������� (�������� �� ��� ���������������� ����� �����)
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpObject();
        }

        // ������ ������ (�������� �� ��� ���������������� ����� �����)
        if (Input.GetKeyDown(KeyCode.Q) && heldObject != null)
        {
            ThrowObject();
        }
    }

    void PickUpObject()
    {
        // Raycast ��� �������� ������� ����� �������
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x);

        if (hit.collider != null && hit.collider.gameObject.tag == "Item")
        {
            heldObject = hit.collider.gameObject;
            heldObject.transform.parent = transform; // ������� ������ �������� ������

            // �������������: ��������� ���������� ������������� ��� ��������� (������������� ��������)
            heldObject.GetComponent<Rigidbody2D>().simulated = false;
        }
    }

    void ThrowObject()
    {
        // �������� ����������� ������ �� ������ ����������� ������
        Vector2 throwDirection = Vector2.right * transform.localScale.x;

        // ��������� ���� � ����������� ������
        heldObject.GetComponent<Rigidbody2D>().AddForce(throwDirection * throwForce);

        // ����������� ������ �� ������ � ����� �������� ������
        heldObject.transform.parent = null;
        heldObject.GetComponent<Rigidbody2D>().simulated = true;

        heldObject = null; // �������� ������ �� ������������ ������
    }

    // ��������� ���������� (������������ � ����������)
    public float throwForce = 10.0f;
}
