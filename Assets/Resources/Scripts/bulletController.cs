using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
   public float speed;
    private float time = 0;
    public GameObject smoke;
    // Update is called once per frame
    void Update()
    {
        if (time == 30)
        {
            Destroy(this.gameObject);
            Instantiate(smoke,this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        time++;
        this.transform.position += transform.up * Time.deltaTime * speed;
    }
}
