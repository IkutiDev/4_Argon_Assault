using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Collider _enemyBoxCollider;
    private void Awake()
    {
        _enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        _enemyBoxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}
