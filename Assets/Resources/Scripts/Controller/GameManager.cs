using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public EneyController tankEnemy;
    public int scorePlayer;
    public Text scoreTxt;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Update()
    {
        scoreTxt.text = "score : " + scorePlayer.ToString();
    }

    public void addScore()
    {

        scorePlayer += 10;
        Instantiate(tankEnemy, this.transform.position, this.transform.rotation);
    }
}
