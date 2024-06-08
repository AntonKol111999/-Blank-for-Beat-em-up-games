using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public int Room_Lvl = 1;
    public Text Room_Lvl_Text;

    bool Room_Clear = false;
    public int Number_of_enemies_in_the_room;

    public Sprite Luke_Sprite; // Картинка люка
    public Sprite Ladder_Sprite; // картинка лестницы

    public Transform Player;
    public Transform Player_starting_position;

    public Spawner spawner;

    public Enemy_Characteristics enemy_Characteristics;

    private void Start()
    {
        Room_Lvl = 1;
    }

    void Room_Start()
    {
        spawner.Potion_of_Healing_Spawner(Room_Lvl); // Спаун зелья личения
        // все что ниже спаун врага
        Player.position = Player_starting_position.position;

        GetComponent<SpriteRenderer>().sprite = Luke_Sprite;
        GetComponent<BoxCollider2D>().enabled = false;
                
        if (Room_Lvl < 10)
        {
            Number_of_enemies_in_the_room = 1;
        }
        if (Room_Lvl > 9 && Room_Lvl < 20)
        {
            Number_of_enemies_in_the_room = 2;
        }
        if (Room_Lvl > 19 && Room_Lvl < 30)
        {
            Number_of_enemies_in_the_room = 3;
        }
        if (Room_Lvl > 29 && Room_Lvl < 40)
        {
            Number_of_enemies_in_the_room = 4;
        }
        if (Room_Lvl > 39 && Room_Lvl < 50)
        {
            Number_of_enemies_in_the_room = 5;
        }
        if (Room_Lvl > 49 && Room_Lvl < 60)
        {
            Number_of_enemies_in_the_room = 6;
        }
        if (Room_Lvl > 60)
        {
            Number_of_enemies_in_the_room = 7;
        }        

        //Number_of_enemies_in_the_room = Number_of_enemies_in_the_room * 2;

        enemy_Characteristics.EnemyUpdateStats(Room_Lvl);

        spawner.Enemy_Spawner(Number_of_enemies_in_the_room);
    }

    private void OnTriggerEnter2D()
    {
        Room_Lvl++;
        Room_Start();
    }

    private void Update()
    {
        if (Number_of_enemies_in_the_room <= 0)
        {
            Room_Clear = true;
        }
        if (Room_Clear == true)
        {
            GetComponent<SpriteRenderer>().sprite = Ladder_Sprite;
            GetComponent<BoxCollider2D>().enabled = true;
            Room_Clear = false;
        }

        Room_Lvl_Text.text = "Room Level " + Room_Lvl;
    }
}
