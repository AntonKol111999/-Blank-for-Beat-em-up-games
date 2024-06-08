using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCredits : MonoBehaviour
{
    public float scrollSpeed = 20.0f;
    public RectTransform creditsText;

    public Transform targetObject;
    void Start()
    {
        // Переместить объект 1 на позицию объекта 2
        transform.position = targetObject.position;
    }

    void Update()
    {
        creditsText.position += Vector3.up * scrollSpeed * Time.deltaTime;

        if (creditsText.anchoredPosition.y > Screen.height)
        {
            transform.position = targetObject.position;
        }
    }
}
