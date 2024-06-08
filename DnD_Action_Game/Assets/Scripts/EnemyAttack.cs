using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Collider2D triggerCollider; // ������ ������ �����

    bool Player_isTrigger;
    bool isAttack;

    // �������� �����
    public Animator animator;

    // ��������� ����� ������
    public PlayerAttack playerAttack;

    // �������� ����� (� ��������)
    public float attackInterval = 2.45f; // ������� ���� � �������

    public int damage;

    float speedEdit;

    void Start()
    {
        //playerAttack = player.GetComponent<PlayerAttack>();
        //StartCoroutine(AttackCoroutine());
    }

    private void OnTriggerEnter2D (Collider2D other)
    {        
        if (other.CompareTag("Player") && other.IsTouching(triggerCollider))
        {
            Player_isTrigger = true;
            isAttack = true;            
            InvokeRepeating("Attack", 0.0f, attackInterval);
            // ��������� ����� �� �����
            //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            speedEdit = GetComponent<PlayerFollower>()._speed;
            GetComponent<PlayerFollower>()._speed = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Player_isTrigger = false;
        Debug.Log("����� ����� �� �������");
        
        CancelInvoke("Attack");
        // ���� ����� ����� ��������
        //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    // �������, ���������� � ����� �������� �����
    public void AttackComplete()
    {
        if (Player_isTrigger == true)
        {
            Debug.Log("���� ����� �� ������");            
            playerAttack.TakeDamage(damage);
        }        
    }

    public void Dynamic_End_Anim()
    {
        GetComponent<PlayerFollower>()._speed = speedEdit;
        isAttack = false;
    }
}
