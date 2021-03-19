using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JohnMovement : MonoBehaviour
{
    //movimiento
    public float Speed;
    public float JumpForce;
    //balas
    public GameObject BulletPrefab;
    //colisiones de las balas
    private Rigidbody2D Rigidbody2D;
    //animacion de John
    private Animator Animator;
    //fisicas
    private float Horizontal;
    private bool Grounded;
    private float LastShoot;
    //vida y puntos
    public int Health = 5;
    public int maxHealth = 5;
    public int crates = 4;
    public GameObject[] lifes;
    public GameObject[] cajas;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Movimiento
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Animator.SetBool("running", Horizontal != 0.0f);
        // Detectar Suelo
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
            Grounded = true;
        else Grounded = false;
        // Salto
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
            Jump();
        // Disparar
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f){
            Shoot();
            LastShoot = Time.time;
            }
        //vida
        if(Health == 4)
            Destroy(lifes[4].gameObject);
        else if(Health == 3)
            Destroy(lifes[3].gameObject);
        else if(Health == 2)
            Destroy(lifes[2].gameObject);
        else if(Health == 1)
            Destroy(lifes[1].gameObject);
        //crates
        if(crates == 3)
            Destroy(cajas[3].gameObject);
        else if(crates == 2)
            Destroy(cajas[2].gameObject);
        else if(crates == 1)
            Destroy(cajas[1].gameObject);
        else if(crates == 0)
            Destroy(cajas[0].gameObject);
}
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health-=1;
        if (Health == 0){
            Destroy(gameObject);
            Destroy(lifes[0].gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("crate")){
            Destroy(col.gameObject);
            crates-=1;
        }
        if(col.CompareTag("Finish") && crates == 0){
            SceneManager.LoadScene(2);
        }
    }

}