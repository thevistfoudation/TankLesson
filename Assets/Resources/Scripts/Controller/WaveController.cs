using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
public class WaveController : MonoBehaviour
{
    public List<EneyController> _tankEnemy = new List<EneyController>();
    public EneyController enemySample;
    [SerializeField] private Transform[] _gate;
    private int _enemyInWave = 0;
    private void Start()
    {
        Observer.Instance.AddObserver(TOPICNAME.ENEMYDESTROY, CalculateWave);
        _tankEnemy.Add(enemySample);
        CreateWave();
    }
    public void CreateWave()
    {
        for (int i = 0; i < _tankEnemy.Count; i++)
        {
            var enemy = _tankEnemy[i];
            var gate = Random.Range(0, _gate.Length);
            Instantiate(enemy, _gate[gate].position, _gate[gate].rotation);
        }
    }

    private void CalculateWave(object data)
    {
        _enemyInWave += 1;
        if (_enemyInWave == _tankEnemy.Count)
        {
            if (_tankEnemy.Count <= 5)
            {
                _tankEnemy.Add(enemySample);
                CreateWave();
            }
            else
            {
                CreateWave();
                _enemyInWave = 0;
            }
        }
    }
}

public class Wave : SingletonMonoBehaviour<WaveController>
{

}
