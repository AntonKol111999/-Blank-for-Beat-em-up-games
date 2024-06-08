using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int Enemy_HP = 100;
    public Slider Enemy_HP_Slider;

    private void Start()
    {
        Enemy_HP_Slider.minValue = Enemy_HP;
    }

    public void TakeDamage(int Damage)
    {
        Enemy_HP -= Damage;
    }

    private void Update()
    {
        Enemy_HP_Slider.value = Enemy_HP;

        if (Enemy_HP <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

}
