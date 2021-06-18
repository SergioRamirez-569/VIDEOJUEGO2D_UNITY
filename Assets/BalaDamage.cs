using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaDamage : MonoBehaviour
{

    public float damage;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.tag == "Player")
        {
            PlayerLife.life -= damage;
        }
    }
}
