using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    //täs tehään tästä scriptistä instance eli tähän scriptiin otetaan monest paikast yhteyttä
    public static BulletPoolManager Instance;

    //täs teen luodille referenssin et voi käyttää scriptis sitä
    public GameObject bulletprefab;
    public int bulletamount = 30;

    private Queue<GameObject> bulletpool = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        InitializePool();
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    
    void InitializePool()
    {
        for (int i = 0; i < bulletamount; i++)
        {
            GameObject bullet = Instantiate(bulletprefab);
            bullet.SetActive(false);
            bulletpool.Enqueue(bullet);
        }
    }
    public GameObject GetBullet(){
        if(bulletpool.Count > 0 ){
            GameObject bullet = bulletpool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            return null;
        }
        
    }
    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletpool.Enqueue(bullet);
    }
}
