using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoleccionFrutas : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.5f);
        }
    }



}
