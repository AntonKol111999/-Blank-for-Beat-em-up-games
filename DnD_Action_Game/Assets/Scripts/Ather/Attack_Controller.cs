using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour
{
    public int attack_Damage = 10; // Урон от атаки мечом
    public GameObject Sword;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") // Проверка тега collider-а
        {
            Enemy enemy = other.GetComponent<Enemy>(); // Получение ссылки на компонент врага
            enemy.TakeDamage(attack_Damage); // Нанесение урона врагу (10 единиц)
            Debug.Log("Попад!");
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
