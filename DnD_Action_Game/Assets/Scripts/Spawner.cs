using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    int Enemy_Lvl;

    public GameObject objectToSpawn; // Объект, который будет спауниться (Враг)

    public GameObject Potion_of_Healing; // Префаб для спауна зелья личения

    public Transform spawnPoint_1; // Позиция, где будет спауниться объект
    public Transform spawnPoint_2;
    public Transform spawnPoint_3;
    public Transform spawnPoint_4;
    public Transform spawnPoint_5;
    public Transform spawnPoint_6;
    public Transform spawnPoint_7;

    private void Start()
    {
        //Enemy_Spawner(1);        
    }
    //Room_Lvl % 5 == 0
    public void Potion_of_Healing_Spawner(int Room_Lvl)
    {
        if (true) // Выполняется каждый раз когда уровень комнаты кратен 5
        {
            Debug.Log("уровень комнаты кратен 5");

            //GameObject Potion = Potion_of_Healing;

            int randomInt = Random.Range(1, 8);

            switch (randomInt)
            {
                case (1):
                    Instantiate(Potion_of_Healing, spawnPoint_1.position, spawnPoint_1.rotation);
                    break;
                case (2):
                    Instantiate(Potion_of_Healing, spawnPoint_2.position, spawnPoint_2.rotation);
                    break;
                case (3):
                    Instantiate(Potion_of_Healing, spawnPoint_3.position, spawnPoint_3.rotation);
                    break;
                case (4):
                    Instantiate(Potion_of_Healing, spawnPoint_4.position, spawnPoint_4.rotation);
                    break;
                case (5):
                    Instantiate(Potion_of_Healing, spawnPoint_5.position, spawnPoint_5.rotation);
                    break;
                case (6):
                    Instantiate(Potion_of_Healing, spawnPoint_6.position, spawnPoint_6.rotation);
                    break;
                case (7):
                    Instantiate(Potion_of_Healing, spawnPoint_7.position, spawnPoint_7.rotation);
                    break;
            }
        }
    }    

    public void Enemy_Spawner(int Number_Of_Enemies)
    {
        //Number_Of_Enemies = Number_Of_Enemies / 2;

        for (int i = 0; i < Number_Of_Enemies; i++)
        {
            int randomInt = Random.Range(1, 8);

            switch (randomInt)
            {
                case (1):
                    Instantiate(objectToSpawn, spawnPoint_1.position, spawnPoint_1.rotation);
                    break;
                case (2):
                    Instantiate(objectToSpawn, spawnPoint_2.position, spawnPoint_2.rotation);
                    break;
                case (3):
                    Instantiate(objectToSpawn, spawnPoint_3.position, spawnPoint_3.rotation);
                    break;
                case (4):
                    Instantiate(objectToSpawn, spawnPoint_4.position, spawnPoint_4.rotation);
                    break;
                case (5):
                    Instantiate(objectToSpawn, spawnPoint_5.position, spawnPoint_5.rotation);
                    break;
                case (6):
                    Instantiate(objectToSpawn, spawnPoint_6.position, spawnPoint_6.rotation);
                    break;
                case (7):
                    Instantiate(objectToSpawn, spawnPoint_7.position, spawnPoint_7.rotation);
                    break;
            }
        }        
    }
}
