using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class GameSession : MonoBehaviour
{
    // config params
    [Range(0.1f , 10)] [SerializeField] public float gameSpeed = 1f;
    [SerializeField] int scorePerBlockDestroyed = 25;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;
    // states
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        //Singleton pattern
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        scoreText.text = currentScore.ToString();
        
    }
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

   
    public void AddToScore(int modifier = 1)
    {
        currentScore += scorePerBlockDestroyed * modifier;
        scoreText.text = currentScore.ToString();
    }


    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    { 
        return isAutoPlayEnabled; 
    }
}
