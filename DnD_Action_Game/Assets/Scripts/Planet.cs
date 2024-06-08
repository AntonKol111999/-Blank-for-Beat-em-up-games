using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]private Transform target; // объект, вокруг которого будет вращаться

    [SerializeField]private float rotationSpeed; // скорость вращения

    [SerializeField] private float selfRotationSpeed; // скорость вращения

    void Update()
    {
        // Вращение вокруг Игрока
        transform.RotateAround(target.position, Vector3.forward, rotationSpeed * Time.deltaTime);

        // Вращение вокруг своей оси
        transform.Rotate(Vector3.forward, selfRotationSpeed * Time.deltaTime);
    }
}
