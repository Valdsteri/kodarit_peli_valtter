using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private float speed = 7f; 

    private float lifeTimer;
    // Start is called before the first frame update

    private void OnEnable()
    {
        lifeTimer = 3.5f;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime * -1);

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            BulletPoolManager.Instance.ReturnBullet(gameObject);
        }
    }
}
