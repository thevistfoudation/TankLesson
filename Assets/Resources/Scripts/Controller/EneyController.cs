using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneyController : TankController
{

    public GameObject Player;
    private void Update()
    {
        Vector3 direction = Player.transform.position;
        var gunDirection = direction - transform.position;

        Move(gunDirection);
        RotateGun(gunDirection);

        if (Random.Range(0, 100) % 50 == 0)
        {
            Shoot();
        }

    }
}
