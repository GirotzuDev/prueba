using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController : MonoBehaviour
{

    public float moveSpeed = 10;
    public Rigidbody2D rb;
    public GameObject doorOpener;
    public GameObject doorKey;
    public bool inDialogue = false;

    private Vector2 moveDirection;
    // Update is called once per frame
    void Update(){
        ProcessInputs();
    }
    void FixedUpdate()
    {
        Move();
    }
 
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX,moveY);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x*moveSpeed,moveDirection.y*moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Key"))
        {
            doorKey.SetActive(false);
            doorOpener.SetActive(true);
        }

    }


}
