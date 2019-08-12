using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathFx;
    [SerializeField] private Transform parent;
    [SerializeField] private int scoreForEnemy=12;
    private Collider _enemyBoxCollider;
    private ScoreBoard _scoreBoard;
    private void Start()
    {
        AddBoxCollider();
        _scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        _enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        _enemyBoxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        _scoreBoard.IncreaseScore(scoreForEnemy);
        GameObject fx =Instantiate(deathFx,transform.position,Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
