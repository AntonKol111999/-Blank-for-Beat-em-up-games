using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    /*
    [SerializeField] private Transform _player;
    [SerializeField] public float _speed;
   
    void Update()
    {
        var direction = (_player.position - transform.position).normalized;
        transform.Translate(direction * _speed);
    }
    */
    public Transform _player; // объект, к которому мы приближаемся
    public float _speed = 2.0f; // скорость приближения

    public Transform object1; // объект 1
    public Transform object2; // объект 2

    Quaternion rotation;

    private void Start()
    {
        // Получаем текущую ротацию объекта
        rotation = transform.rotation;        
    }

    void Update()
    {
        if (_player != null)
        {
            // Вычисляем направление к целевому объекту
            Vector3 direction = _player.position - transform.position;
            direction.Normalize();

            // Перемещаем объект к цели с определенной скоростью
            transform.position += direction * _speed * Time.deltaTime;
        }

        // ПРоверка куда смотрит враг

        if (object1 != null && object2 != null)
        {
            if (object2.position.x > object1.position.x)
            {
                //Debug.Log("Object 2 находится справа от Object 1");
                // Устанавливаем поворот по оси Y равным 180 градусов
                rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, 180, rotation.eulerAngles.z);
            }
            else if (object2.position.x < object1.position.x)
            {
                //Debug.Log("Object 2 находится слева от Object 1");
                // Устанавливаем поворот по оси Y равным 0 градусов
                rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, 0, rotation.eulerAngles.z);
            }
            else
            {
                //Debug.Log("Object 2 находится на одной линии с Object 1");
            }
            

            // Применяем новую ротацию к объекту
            transform.rotation = rotation;
        }
    }
}
