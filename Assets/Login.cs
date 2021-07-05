using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class Login : MonoBehaviour
{
    public InputField usuarioTxt;
    public InputField passwordTxt;

    public void Logear()
    {
        string _log = "`usuarios` WHERE `NOMBRE` LIKE'" + usuarioTxt.text + "'AND `CONTRASEÑA` LIKE '" + passwordTxt.text + "'";
        ConexionMysql _conexionMysql = GameObject.Find("ConexionBaseDeDatos").GetComponent<ConexionMysql>();
        MySqlDataReader Resultado = _conexionMysql.Select(_log);

        if (Resultado.HasRows)
        {
            Debug.Log("Login correcto");
            Resultado.Close();
        }
        else
        {
            Debug.Log("Usuario o contraseña incorrecta");
            Resultado.Close();
        }
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
