using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenSizeInUnits = 16f;
    [SerializeField]  bool gamePause = false;

    //cached references
    GameSession theGameSession;
    Ball theBall;
    float gameSpeed;
    

    private void Start()
    {
        theBall = FindObjectOfType<Ball>();
        theGameSession = FindObjectOfType<GameSession>();
        gameSpeed = theGameSession.gameSpeed;
        
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePause = !gamePause;
        }
        
        if(!gamePause)
        {   theGameSession.gameSpeed = gameSpeed;
            PaddleMovement();
        }
        else
        {
            theGameSession.gameSpeed = 0;
        }

    }

    private void PaddleMovement()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), 1, screenSizeInUnits - 1);
        transform.position = paddlePosition;
    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenSizeInUnits;
        }
    }
    
}
