using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    /*
    [SerializeField] private Transform _player;
    [SerializeField] public float _speed;
   
    void Update()
    {
        var direction = (_player.position - transform.position).normalized;
        transform.Translate(direction * _speed);
    }
    */
    public Transform _player; // ������, � �������� �� ������������
    public float _speed = 2.0f; // �������� �����������

    public Transform object1; // ������ 1
    public Transform object2; // ������ 2

    Quaternion rotation;

    private void Start()
    {
        // �������� ������� ������� �������
        rotation = transform.rotation;        
    }

    void Update()
    {
        if (_player != null)
        {
            // ��������� ����������� � �������� �������
            Vector3 direction = _player.position - transform.position;
            direction.Normalize();

            // ���������� ������ � ���� � ������������ ���������
            transform.position += direction * _speed * Time.deltaTime;
        }

        // �������� ���� ������� ����

        if (object1 != null && object2 != null)
        {
            if (object2.position.x > object1.position.x)
            {
                //Debug.Log("Object 2 ��������� ������ �� Object 1");
                // ������������� ������� �� ��� Y ������ 180 ��������
                rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, 180, rotation.eulerAngles.z);
            }
            else if (object2.position.x < object1.position.x)
            {
                //Debug.Log("Object 2 ��������� ����� �� Object 1");
                // ������������� ������� �� ��� Y ������ 0 ��������
                rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, 0, rotation.eulerAngles.z);
            }
            else
            {
                //Debug.Log("Object 2 ��������� �� ����� ����� � Object 1");
            }
            

            // ��������� ����� ������� � �������
            transform.rotation = rotation;
        }
    }
}
