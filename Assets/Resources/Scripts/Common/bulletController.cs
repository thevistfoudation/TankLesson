using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MoveController
{
    private float time = 0;
    public GameObject smoke;
    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.up * Time.deltaTime * speed;
        Move(this.transform.up);
        BulletEx();
    }

    protected virtual void BulletEx()
    {
        if (time == 30)
        {
            Destroy(this.gameObject);
            Instantiate(smoke, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        time++;
    }
}
