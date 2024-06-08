using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public Player_Characteristics player;
    int Restoring_Health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Player entered the collider!");

            Restoring_Health = player.Max_HP / 2;

            player.HP += Restoring_Health;

            Destroy(this);
        }
    }
}
