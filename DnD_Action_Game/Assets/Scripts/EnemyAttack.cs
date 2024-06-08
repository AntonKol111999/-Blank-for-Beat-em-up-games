using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Collider2D triggerCollider; // тригер радиус атаки

    bool Player_isTrigger;
    bool isAttack;

    // Анимация атаки
    public Animator animator;

    // Нанесение урона игроку
    public PlayerAttack playerAttack;

    // Интервал атаки (в секундах)
    public float attackInterval = 2.45f; // сколько атак в секунду

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
            // Остановка врага на месте
            //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            speedEdit = GetComponent<PlayerFollower>()._speed;
            GetComponent<PlayerFollower>()._speed = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Player_isTrigger = false;
        Debug.Log("Игрок выщел из тригера");
        
        CancelInvoke("Attack");
        // Араг сново может двигатся
        //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    // Функция, вызываемая в конце анимации атаки
    public void AttackComplete()
    {
        if (Player_isTrigger == true)
        {
            Debug.Log("Враг попал по Игроку");            
            playerAttack.TakeDamage(damage);
        }        
    }

    public void Dynamic_End_Anim()
    {
        GetComponent<PlayerFollower>()._speed = speedEdit;
        isAttack = false;
    }
}
