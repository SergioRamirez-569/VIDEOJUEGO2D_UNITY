using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    public static int Score = 0;
    public string ScoreString = "Score";

    public Text TextScore;

    public static GameControler GameController;

    void Awake()
    {
        GameController = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TextScore != null)
        {
            TextScore.text = ScoreString + Score.ToString();
            if(Score == 160)
            {

                    Player1.muerteExterna = true;
                    Debug.Log("GANASTE EL JUEGO");

            }
        }
    }
}
