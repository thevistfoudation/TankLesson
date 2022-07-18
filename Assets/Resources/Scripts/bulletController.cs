using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
   public float speed;
    private float time = 0;

    // Update is called once per frame
    void Update()
    {
        if (time == 80000)
        {
            Destroy(this.gameObject);
        }
        time++;
        this.transform.position += transform.up * Time.deltaTime * speed;
    }
}
