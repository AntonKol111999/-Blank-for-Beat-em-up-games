using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Characteristics : MonoBehaviour
{ 
    public Animator animator;

    public int Max_HP;
    public int HP;

    public int XP;

    public Transform attackPoint;
    public LayerMask plyerLayers;

    public float attackRange;
    public int attackDamage = 10;

    public float attackRate = 0.8f; // ����������� ���� � �������
    float nextAttackTime = 0f;

    public Player_Characteristics player_Characteristics;

    public Room room;

    public GameObject objectToDestroy;

    private void Start()
    {
        HP = Max_HP;
    }   

    public void TakeDamage(int damage)
    {        
        HP -= damage;

        if (HP <= 0)
        { 
            Die();
        }
        else
        {
            // ��������� �������� ��������� �����
            animator.SetTrigger("Hurt");                
        }
    }

    public void Die()
    {
        Debug.Log("���� ����");

        // �������� ������
        animator.SetBool("isDead", true);

        //����� �������� ����
        player_Characteristics.Update_XP(XP);

        // �������� ������ �����
        room.Number_of_enemies_in_the_room--;

        Destroy(objectToDestroy);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<PlayerFollower>().enabled = false;
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        this.enabled = false;
    }

    public void EnemyUpdateStats(int level)  // �������� �������������� ����� � ����������� ������� �������.
    {
        Max_HP += level * 1; // ����������� �������� �� 10 ������ �� ������ �������
        GetComponent<EnemyAttack>().damage += level * 1; // ����������� ���� �� 2 ������� �� ������ �������
        XP += level * 1; 
    }
}
