using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject prefabBala;

    public Transform posx;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigibody;
    public float speed = 8f;
    public float forceJump=10f;
    public bool canJump=false;
    public Animator animator;
    public float Horizontal;

    private AudioSource SonidoSalto;

    private float LastShoot;
    private int Health=4;

    public static bool muerteExterna = false;

    public bool start = false;

    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SonidoSalto = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(start == false)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                start = true;
            }
        }
        //if(start == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.L))
        //    {
        //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //    }
        //}
        if (start == true )
        {
            menuPrincipal.SetActive(false);
            //Horizontal = Input.GetAxisRaw("Horizontal");
            //if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            //else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            if (muerteExterna)
            {
                muerteExterna = false;
                Destroy(gameObject);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                posx.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
                spriteRenderer.flipX = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                posx.position -= new Vector3(1, 0, 0) * speed * Time.deltaTime;
                spriteRenderer.flipX = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
            {
                animator.SetBool("Jump", true);
                rigibody.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
                SonidoSalto.Play();
            }
            if (Input.GetKey(KeyCode.X) && Time.time > LastShoot + 0.25f)
            {
                Shoot();
                LastShoot = Time.time;
            }
        }


    }

        private void Shoot()
        {
            Vector3 direction;
            if (transform.localScale.x == 1.0f) direction = Vector2.right;
            else direction = Vector2.left;
                GameObject bala = Instantiate(prefabBala, transform.position + direction *1.0f, Quaternion.identity);
            bala.GetComponent<Bala>().SetDirection(direction);
        }
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "suelito")
            {
                animator.SetBool("Jump",false);
                canJump = true;
            }
        }
        public void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "suelito")
            {
                //
                canJump = false;
            }
            if (collision.gameObject.tag == "tagGema")
            {
                Debug.Log("Encontro el portal");
                SceneManager.LoadScene("ESCENA1");
            }
            if (collision.gameObject.tag == "obstaculos")
            {
                posx.position = new Vector3(-8, -3, 0);
            }
            if (collision.gameObject.tag == "Maestra")
            {
                Debug.Log("Pudiste Sobrevivir");
                SceneManager.LoadScene("SceneFinal");
            }


    }
    public void Hit()
    {
        Debug.Log("daños");
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);
    }

}
