using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhapsodySkill : MonoBehaviour
{
    public GameObject bullet;

    public Transform bulletSpawn;

    public float fireRate = 0.5f;
    public float bulletSpeed = 10f;
    public float duration = 1f;

    public int maxShots = 6; 
    
    public bool activeSkill = false;

    private float skillCooldown;
    private int shotsFired;
    private float abilityTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !activeSkill)
        {
            activeSkill = true;
            skillCooldown = 0f;
            shotsFired = 0;
            abilityTime = 0f;
        }

        if (activeSkill)
        {
            Rhapsody();
        }
    }

    void Rhapsody()
    {
        abilityTime += Time.deltaTime;

        if (skillCooldown <= 0 && shotsFired < maxShots)
        {
            FireProjectile();
            shotsFired++;
            skillCooldown = fireRate;
        }
        skillCooldown -= Time.deltaTime;

        if (abilityTime >= duration || shotsFired >= maxShots)
        {
            activeSkill = false;
        }
    }

    void FireProjectile()
    {
        GameObject projectile = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);

        if (shotsFired == maxShots - 1)
        {
            Renderer renderer = projectile.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.red;
            }
        }

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawn.forward * bulletSpeed;
    }
}
