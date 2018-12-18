using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    float cooldownTime;
    float cooldown;

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (cooldown <= 0)
        {
            Instantiate(projectile, firePoint.position, Quaternion.identity);
            cooldown = cooldownTime;
        }

        if (cooldown > 0)
            cooldown -= Time.deltaTime;
    }
}
