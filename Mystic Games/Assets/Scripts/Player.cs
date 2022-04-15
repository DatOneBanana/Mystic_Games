using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    public float moveSpeed = 1f;
    
    private Vector2 moveInput;
    private Rigidbody2D rb;

    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }
}
