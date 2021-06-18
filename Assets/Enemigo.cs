using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject Bruja;
    public GameObject prefabBala;

    private float LastShoot;
    private int HealthE = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame 
    public void Update()
    {
        if (Bruja == null)
        {
            return;
        }
        Vector3 direction = Bruja.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        float distance = Mathf.Abs(Bruja.transform.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        GameObject bala = Instantiate(prefabBala, transform.position + direction * 1.0f, Quaternion.identity);
        bala.GetComponent<Bala>().SetDirection(direction);
    }
    public void Hit()
    {
        Debug.Log("DAÑO ENEMIGO");
        HealthE = HealthE - 1;
        if (HealthE == 0) Destroy(gameObject);
    }

}
