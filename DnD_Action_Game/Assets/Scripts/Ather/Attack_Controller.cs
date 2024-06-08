using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour
{
    public int attack_Damage = 10; // ���� �� ����� �����
    public GameObject Sword;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") // �������� ���� collider-�
        {
            Enemy enemy = other.GetComponent<Enemy>(); // ��������� ������ �� ��������� �����
            enemy.TakeDamage(attack_Damage); // ��������� ����� ����� (10 ������)
            Debug.Log("�����!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Sword.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Sword.SetActive(false);
        }
    }
}
