using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    
    Transform target;
    
    
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;        
    }

    
    void Update()
    {        
        AimWeapon();    
    }

    void AimWeapon()
    {
        if (target != null)
        {
            weapon.LookAt(target.position);
        }
    }
}
