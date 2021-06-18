using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    static public float life=100;
    private Slider lifebar;
    // Start is called before the first frame update
    void Start()
    {
        lifebar = GameObject.FindGameObjectWithTag("lifebar").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        lifebar.value = life;
        if (lifebar.value == 0)
        {
            Player1.muerteExterna = true;
        }
        

    }
}
