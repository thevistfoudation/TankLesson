using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
public class bulletController : MoveController
{
    public float time = 0;
    public DestroyController smoke;
    public float damage;
    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.up * Time.deltaTime * speed;
        Debug.LogError(this.gameObject.tag);
        Move(this.transform.up);
        BulletEx();
    }

    protected virtual void BulletEx()
    {
        if (time == 30)
        {
            
            PoolingObject.DestroyPooling<bulletController>(this);
            Instantiate(smoke, this.gameObject.transform.position, this.gameObject.transform.rotation);

        }
        time++;
    }

    public float CalculateHp(float hp)
    {
        var hpLeft = hp -  damage;
        Instantiate(smoke, this.gameObject.transform.position, this.gameObject.transform.rotation);
        return hpLeft;
    }

}
