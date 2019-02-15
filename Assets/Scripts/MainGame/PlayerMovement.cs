using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 5;
    [SerializeField] private float jumpHeight = 2;

    private Rigidbody2D body;
    private Animator animator;
    // Start is called before the first frame update

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        SwitchInput();
    }

    void SwitchInput()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.Space))
        {
            Catch();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Crouch();
        }
        
    }

    void Crouch()
    {
        Debug.Log("Crouch");
    }

    void Jump()
    {
        body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        Debug.Log("Jump");
    }

    void Catch()
    {
        Debug.Log("Catch");
    }

    void Run()
    {
        body.velocity = new Vector2(horizontalSpeed, body.velocity.y);
        animator.SetFloat("speed", horizontalSpeed);
    }


}
