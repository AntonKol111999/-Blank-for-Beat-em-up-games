using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;

    [SerializeField] private float Moving_Speed = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 Input_Vector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            Input_Vector.y = 1f;
            animator.SetFloat("Move", 1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Input_Vector.y = -1f;
            animator.SetFloat("Move", 1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Input_Vector.x = -1f;

            Vector3 newRotation = new Vector3(0, 180, 0);
            transform.eulerAngles = newRotation;

            animator.SetFloat("Move", 1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Input_Vector.x = 1f;

            Vector3 newRotation = new Vector3(0, 0, 0);
            transform.eulerAngles = newRotation;

            animator.SetFloat("Move", 1f);
        }
        
        Input_Vector = Input_Vector.normalized;

        rb.MovePosition(rb.position + Input_Vector * (Moving_Speed * Time.fixedDeltaTime));

        if (Input_Vector.x == 0 && Input_Vector.y == 0)
        {
            animator.SetFloat("Move", 0f);
        }

        if (Input.GetKey(KeyCode.F))  // кнопка атаки
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Attack", false);
        }
        //else { animator.SetBool("Attack", false); }
    }
}
