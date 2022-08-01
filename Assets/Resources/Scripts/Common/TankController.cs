using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    protected void RotateGun(Vector3 direction)
    {
        gun.up = direction;
    }

    public void Shoot()
    {
        Instantiate(bullet, transhoot.transform.position, transhoot.transform.rotation);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hp = bullet.CalculateHp(hp,level);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            hp = bullet.CalculateHp(hp,level);
        }
    }

}
