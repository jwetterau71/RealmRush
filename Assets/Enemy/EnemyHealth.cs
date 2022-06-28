using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoints = 0;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Hit");
        ProcessHit(other.GetComponent<Weapon>().GetWeaponPower());
    }


    void ProcessHit(int damage)
    {
        Debug.Log(damage.ToString());
        currentHitPoints -= damage;

        if(currentHitPoints <= 1)
        {            
            KillEnemy();
            //update score
        }
        else
        {
            //show hit
            //update score
        }
    }

    void KillEnemy()
    {
        gameObject.SetActive(false);
    }
}
