using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    [SerializeField] SceneController sceneController;

    private void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
    }


    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneController.LoadNextScene();
        }
    }

    
        
    
}
