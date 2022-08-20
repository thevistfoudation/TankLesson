using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
public class DestroyController : MonoBehaviour
{
    public void DestroySmoke()
    {
        //PoolingObject.DestroyPooling<DestroyController>(this);
        Destroy(this.gameObject);
    }
}
