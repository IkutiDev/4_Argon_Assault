using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("In seconds")] [SerializeField] private float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")][SerializeField] private GameObject deathFx;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        print("Player dying");
        SendMessage("TurnOffControls");
        deathFx.SetActive(true);
        Invoke(nameof(ReloadGame), levelLoadDelay);
    }

    private void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
