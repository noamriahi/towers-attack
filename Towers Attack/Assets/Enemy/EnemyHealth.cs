using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints=5;
    int currentHitPoint = 0;

    void OnEnable()
    {
        currentHitPoint = maxHitPoints;
    }

    void OnParticleCollision(GameObject other) {
        ProcessHit();
    }
    void ProcessHit()
    {
        currentHitPoint--;
        Debug.Log(currentHitPoint);
        if(currentHitPoint<=0){
            gameObject.SetActive(false);
        }
    }
}
