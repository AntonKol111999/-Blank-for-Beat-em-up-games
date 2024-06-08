using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]private Transform target; // ������, ������ �������� ����� ���������

    [SerializeField]private float rotationSpeed; // �������� ��������

    [SerializeField] private float selfRotationSpeed; // �������� ��������

    void Update()
    {
        // �������� ������ ������
        transform.RotateAround(target.position, Vector3.forward, rotationSpeed * Time.deltaTime);

        // �������� ������ ����� ���
        transform.Rotate(Vector3.forward, selfRotationSpeed * Time.deltaTime);
    }
}
