using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitpoints = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHitpoints = maxHitPoints;
    }

    void Start() {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other) {
        ProcessHit();
    }

    void ProcessHit() {
        currentHitpoints--;

        if(currentHitpoints <= 0) {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
