using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    public float speed;


    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * speed;
        
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
        
    }

    internal void SetDirection(Animator animator)
    {
        throw new NotImplementedException();
    }

    public void DestruirBala()
    {
        Destroy(gameObject);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player1 bruj = collision.collider.GetComponent<Player1>();
        Enemigo ene = collision.collider.GetComponent<Enemigo>();
        if(bruj != null)
        {
            bruj.Hit();

        }
        if(ene != null)
        {
            ene.Hit();

        }
        DestruirBala();
    }
}
