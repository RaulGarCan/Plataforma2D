using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    private Rigidbody2D Rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        // almacena -1 si pulsamos tecla a
        // almacena 0 si no pulsamos nada
        // almacena 1 si pulsamos tecla d
        Rigidbody2D.velocity = new Vector2(horizontal,Rigidbody2D.velocity.y);
    }
}
