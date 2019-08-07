using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
     Invoke(nameof(LoadFirstScene),5f);   
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
