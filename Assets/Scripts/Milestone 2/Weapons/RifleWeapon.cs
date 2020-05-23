//Rifle Weapon Script for Full Auto Weaponized Guns

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleWeapon : Weapon
{
    
    //Ammo Count
    public float ammoCount = 15;
    //Bullet Prefab
    [SerializeField] private GameObject prefabBullet;
    //Fire Point for the bullet to spawn
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1.0f;
    //Boolean
    [SerializeField] private bool isShooting = false;
    //Countdown
    private float ShootingCountdown = 2;

    public GameObject muzzleEffect;
    public GameObject collisionEffect;
    public override void Start()
    {
        ShootingCountdown = 0;
    }
    public override void OnPullTrigger()
    {
        isShooting = true;
        base.OnPullTrigger();
    }

    public override void OnReleaseTrigger()
    {
        isShooting = false;
        base.OnReleaseTrigger();
    }

    protected override void Update()
    {
        // count down each frame
        if (ShootingCountdown > 0)
        {
            ShootingCountdown -= Time.deltaTime;
        }

        if (isShooting && ammoCount > 0 && ShootingCountdown <= 0)
        {
            ammoCount--;
            Fire();
            ShootingCountdown = fireRate;
        }
    }
    //Fire Bullet Function
    public override void Fire()
    {
        GameObject bullet = Instantiate(prefabBullet, firePoint.position, firePoint.rotation) as GameObject;
        BulletData bulletData = bullet.GetComponent<BulletData>();
        Flash();
        if (bulletData != null)
        {
            bulletData.damageDone = Damage;
            bulletData.moveSpeed = Speed;
        }
    }
    void Flash()
    {
        GameObject muzzleFlash = Instantiate(muzzleEffect, firePoint.position, firePoint.rotation);
        Destroy(muzzleFlash, .05f);
        muzzleFlash.GetComponent<ParticleSystem>().Play();
    }
    void Collision()
    {
        GameObject collision = Instantiate(muzzleEffect, transform.position, Quaternion.identity);
        collision.GetComponent<ParticleSystem>().Play();
    }
}
