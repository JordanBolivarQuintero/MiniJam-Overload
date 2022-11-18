using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawpoi;
    private int wave = 10;
    [NonSerialized] public int enemiesAlive;

    #region Singleton

    static SpawnEnemies _spawnEnemies;

    private void Awake()
    {
        _spawnEnemies = this;
    }

    #endregion

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        //enemiesAlive = (wave * 2) - 5;
        
        for (int i = 0; i < (wave * 2) - 5; i++)
        {
            Instantiate(enemyPrefab, spawpoi[UnityEngine.Random.Range(0,17)], transform.parent);
            
            yield return new WaitForSeconds(0.3f);
            wave++;
        }

        StartCoroutine(Spawn());
    }
    
    /*IEnumerator SpawnWithControl()
    {
        for (int i = 0; i < (wave*2)-5; i++)
        {
            if (enemiesAlive < 25)
            {
                Instantiate(enemyPrefab, spawpoi, transform.parent);
                enemiesAlive++;
                yield return new WaitForSeconds(2); 
            }
            else
            {
                yield return new WaitUntil(()=> enemiesAlive <= 20);
            }

        }
    }*/
}
