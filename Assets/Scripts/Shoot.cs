using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPoolSpawn;
    [SerializeField] Transform spawn;
    [SerializeField] float rate = 5; //ta raro
    [SerializeField] int magazine = 30;
    List<GameObject> bulletPool = new List<GameObject>(); 
    int bulletPos = 0;
    float timer = 0;

    void Awake()
    {
        GameObject bulletInst = null;
        for (int i = 0; i < magazine; i++)
        {
            bulletInst = Instantiate(bullet, bulletPoolSpawn);           
            bulletPool.Add(bulletInst);
        }
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (bulletPos + 1 < magazine)
            {
                Shooting();
            }
            else if (bulletPos + 1 == magazine)
            {
                Invoke("Reload", 1.2f);
            }
        }
    }

    void Reload()
    {
        bulletPos = 0;
    }

    void Shooting()
    {
        if (timer >= rate * Time.deltaTime)
        {
            timer = 0;
            bulletPool[bulletPos].GetComponent<MoveForward>().Shoot_(spawn.transform, transform);    
            bulletPos++;           
        }
        timer += Time.deltaTime;
    }
}
