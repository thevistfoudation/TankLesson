using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;

public class PlayerController : TankController
{

    public Slider slider_hp;
    public Text levelTxt;
    private void Awake()
    {
        slider_hp.maxValue = hp;
    }

    private void Start()
    {
        //Observer.Instance.AddObserver(TOPICNAME.ENEMYDESTROY, LevelUp);
        this.RegisterListener(EventID.enemyDestroy, (sender, param) =>
        {
            LevelUp((float)param);
        });
    }

    void Update()
    {

        slider_hp.value = hp;
        if (hp <= 0)
        {
            //Destroy(this.gameObject);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical);
        Move(direction);
        Vector3 gunDirection = new Vector3(
               Input.mousePosition.x - Screen.width / 2,
               Input.mousePosition.y - Screen.height / 2
           );
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

    private void LevelUp(float levelEnemy)
    {
        
        level += levelEnemy;
        levelTxt.text = "Level Player: " + level.ToString();
        bullet.damage += 10;
        bullet.speed += 10;
        Debug.LogError("bullet dam" + bullet.damage);
    }
}

public class Player : SingletonMonoBehaviour<PlayerController>
{

}
