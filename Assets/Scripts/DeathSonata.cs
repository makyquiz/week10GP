using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject bullet;

    public Transform bulletSpawn;

    public float bulletSpeed = 10f;
    public float duration = 1f;

    public int maxShots = 1;

    public bool activeSkill = false;

    private float skillCooldown;
    private int shotsFired;
    private float abilityTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !activeSkill)
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

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawn.forward * bulletSpeed;
    }
}
