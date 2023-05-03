using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;
public class GameManager : MonoBehaviour
{
    public EneyController tankEnemy;
    public int scorePlayer;
    public Text scoreTxt;
    private void Awake()
    {

        this.RegisterListener(EventID.enemyDestroy, (sender, param) =>
        {
            addScore();
        });
    }
    private void Update()
    {
        scoreTxt.text = "score : " + scorePlayer.ToString();
    }

    public void addScore()
    {
        scorePlayer += 10;
    }

}

public class GameController : SingletonMonoBehaviour<GameManager>
{

}
