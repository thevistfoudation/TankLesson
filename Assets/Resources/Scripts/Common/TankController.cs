﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
public class TankController : MoveController
{
    public Transform bodyTank;
    public Transform gun;
    public bulletController bullet;
    public Transform transhoot;
    public float hp;
    public float level;
    protected override void Move(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            bodyTank.up = direction;
        }
        base.Move(direction);
    }

    protected virtual void RotateGun(Vector3 direction)
    {
        gun.up = direction;
    }

    public void Shoot()
    {
        //Instantiate(bullet, transhoot.transform.position, transhoot.transform.rotation);
        CreateBullet(transhoot);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != this.gameObject.tag)
        {
            hp = bullet.CalculateHp(hp);
        }
    }

    public bulletController CreateBullet(Transform tranShoot)
    {
         bulletController bulletclone = PoolingObject.createPooling<bulletController>(bullet);
        if (bulletclone == null)
        {
            return Instantiate(bullet, tranShoot.position, tranShoot.rotation);
        }
        bulletclone.time = 0;
        bulletclone.transform.position = transhoot.position;
        bulletclone.transform.rotation = transhoot.rotation;
        bulletclone.damage += level;
        bulletclone.tag = this.tag;
        return bulletclone;
    }
}
