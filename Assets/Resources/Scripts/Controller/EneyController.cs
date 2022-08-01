using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class EneyController : TankController
{
    private void Update()
    {
        var direction =  Player.Instance.gameObject.transform.position;
        var gunDirection = direction - transform.position;
        gunDirection = new Vector3(gunDirection.x, gunDirection.y,0);

        Move(gunDirection);
        RotateGun(gunDirection);

        if (Random.Range(0, 100) % 50 == 0)
        {
            Shoot();
        }

        if (hp <= 0)
        {
            Destroy(this.gameObject);
            Observer.Instance.Notify(TOPICNAME.ENEMYDESTROY, level);
        }
    }
}
