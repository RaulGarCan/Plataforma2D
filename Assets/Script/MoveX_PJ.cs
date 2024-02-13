using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    private Rigidbody2D Rigidbody2D;
    public float Speed;
    public float JumpForce;
    private float horizontal;
    private bool Grounded;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        horizontal = Input.GetAxisRaw("Horizontal");
        // almacena -1 si pulsamos tecla a
        // almacena 0 si no pulsamos nada
        // almacena 1 si pulsamos tecla d
        if(Physics2D.Raycast(transform.position,Vector3.down, 0.1f)){
            Grounded = true;
        }
        else {
            Grounded = false;
        }
        if(Input.GetKeyDown(KeyCode.W) && Grounded){
            Jump();
        }
    }
    void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal,Rigidbody2D.velocity.y);
    }
    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
}
