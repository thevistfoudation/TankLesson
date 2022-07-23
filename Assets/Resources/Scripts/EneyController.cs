using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneyController : MonoBehaviour
{
    public int speed;
    public GameObject bodyTank;
    public GameObject gun;
    public GameObject bullet;
    public GameObject transhoot;

    public GameObject Player;
    private void Update()
    {
        Vector3 direction = Player.transform.position;
        var gunDirection = direction - transform.position;

        if (gunDirection != Vector3.zero)
        {
            this.gameObject.transform.up = gunDirection;
        }
        this.gameObject.transform.position += gunDirection * Time.deltaTime * speed;

        gun.transform.up = gunDirection;

        if (Random.Range(0, 100) % 50 == 0)
        {
            Instantiate(bullet, transhoot.transform.position, transhoot.transform.rotation);
        }

    }
}
