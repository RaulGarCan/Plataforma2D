using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    public AudioClip sonido;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sonido);
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() { }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        DestroyBullet();
        JohnMovement john = collider.GetComponent<JohnMovement>();
        EnemyBehaviour grunt = collider.GetComponent<EnemyBehaviour>();

        //Codigo que colocaremos en la función de OnCollisionEnter2D ...

        if (john != null)
        { //hemos impactado con john
            john.Hit(1);
        }
        if (grunt != null)
        { //hemos impactado con grunt
            grunt.Hit(1);
        }
    }
}
