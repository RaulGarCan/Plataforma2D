using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class JohnMovement : MonoBehaviour
{
    private float LastShoot;
    private Rigidbody2D Rigidbody2D;
    public float Speed;
    public float JumpForce;
    private Animator Animator;
    private float horizontal;
    private bool Grounded;
    public GameObject prefabBullet;
    public int MaxHealth;
    private float Health;
    public Image BarraVida;

    // Start is called before the first frame update
    void Start()
    {
        if (MaxHealth == 0)
        {
            MaxHealth = 5;
        }
        Health = MaxHealth;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        horizontal = Input.GetAxisRaw("Horizontal");
        // almacena -1 si pulsamos tecla a
        // almacena 0 si no pulsamos nada
        // almacena 1 si pulsamos tecla d

        Animator.SetBool("running", horizontal != 0.0f);

        if (horizontal < 0.0f)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontal > 0.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
        //Deberá esperar un tiempo mayor para permitir disparar una segunda vez
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;

        if (transform.localScale.x == 1.0f)
            direction = Vector3.right;
        else
            direction = Vector3.left;

        // Pintamos el Prefab en scena, en la posición indicada y la rotación=0
        // La posición se calcula:
        // transform.position -> centro de John
        // direction *0.1f -> offset de desplazamiento
        GameObject bullet = Instantiate(
            prefabBullet,
            transform.position + direction * 0.1f,
            Quaternion.identity
        );

        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit(int danio)
    {
        Health = Health - danio;
        BarraVida.fillAmount = Health / MaxHealth;
        if (Health <= 0)
            Destroy(gameObject);
    }
    public int getMaxHealth(){
        return MaxHealth;
    }
}
