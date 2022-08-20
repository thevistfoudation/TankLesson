using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;

public class PlayerController : TankController
{

    public Slider slider_hp;
    public Text levelTxt;
    public GameObject gun1;
    public Transform tranShoot1;
    public GameObject gun2;
    public Transform tranShoot2;
    private bool _itemGunUp = false;
    private void Awake()
    {
        slider_hp.maxValue = hp;
    }

    private void Start()
    {
        Observer.Instance.AddObserver(TOPICNAME.ENEMYDESTROY, LevelUp);
    }

    void Update()
    {
        levelTxt.text = "Level Player: " + level.ToString();
        gun1.SetActive(_itemGunUp);
        gun2.SetActive(_itemGunUp);
        slider_hp.value = hp;
        if (hp <= 0)
        {
            //Destroy(this.gameObject);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical);
        Move(direction);
 
        var position = Input.mousePosition;
        Vector3 gunDirectionmoba = new Vector3(
              position.x - Screen.width / 2,
              position.y - Screen.height / 2
          );
        RotateGun(gunDirectionmoba);
        if (Input.GetMouseButtonDown(0))
        {
           Shoot();
        }
    }



    protected override void Shoot()
    {
        if (_itemGunUp)
        {
           
            CreateBullet(tranShoot1);
            CreateBullet(tranShoot2);
        }
        base.Shoot();
    }

    private void LevelUp(object data)
    {
        float levelEnemy = (float)data;
        level += levelEnemy;
       
        bullet.damage += 10;
        bullet.speed += 10;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "itemGunUp")
        {
            _itemGunUp = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "itemHP")
        {
            hp += 50;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "itemLevel")
        {
            level += 100;
            Destroy(collision.gameObject);
        }
        base.OnTriggerEnter2D(collision);
    }

}

public class Player : SingletonMonoBehaviour<PlayerController>
{

}
