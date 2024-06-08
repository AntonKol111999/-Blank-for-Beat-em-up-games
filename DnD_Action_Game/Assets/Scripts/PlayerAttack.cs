using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{    
    public float attackRate = 0.8f; // колличество атак в сегунду
    float nextAttackTime = 0f;

    public Animator anim;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange;    
    public int attackDamage = 20;    

    void Player_Attack()
    {
        anim.SetTrigger("Attack");        
    }

    void Anim_Player_Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy_Characteristics>().TakeDamage(attackDamage);
        }
    }

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.R) && GetComponent<Player_Characteristics>().Stamina >= 10)
            {
                GetComponent<Player_Characteristics>().Stamina -= 10;
                Player_Attack();
                nextAttackTime = Time.time + 1f / attackRange;
            }
        }             
    }

    public void TakeDamage(int damage) // получние урона
    {
        GetComponent<Player_Characteristics>().HP -= damage;
        Debug.Log("Игрок получил урок: " + damage + ". Осталочь: " + GetComponent<Player_Characteristics>().HP);
                // проиграть анимацию получения урона
        anim.SetTrigger("Hurt");

        if (GetComponent<Player_Characteristics>().HP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Герой умер");

        // анимация смерти
        anim.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Player>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        this.enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
