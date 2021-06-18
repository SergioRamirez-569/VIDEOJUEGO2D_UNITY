using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgregarScore : MonoBehaviour
{

    public int Puntaje = 20;

    private void OnDestroy()
    {
        GameControler.Score += Puntaje;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
