using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Pelaajan liikkumisnopeus ns liikkumisen kerroin
    public float moveSpeed = 5f;

    public Rigidbody2D body;

    // Tämä kuuntelee kaikki pelaajan wasd ja nuolinäppäimien painallukset
    private Master controls;
    // Tähän tallennetaan nappien painallukset x ja y akselilla

    private Vector2 moveInput;
    //aseen transform
    public Transform gunTransform;
    
    // Tämä suoritetaan ennen pelin käynnistystä
    private void Awake()
    {
        controls = new Master();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
    }

    private void OnEnable(){
        controls.Enable();
    }

    private void OnDisable(){
        controls.Disable();
    }

    private void FixedUpdate(){
        Move(); 
    }

    private void Move(){
        moveInput = controls.Player.Move.ReadValue<Vector2>();
        Vector2 movement = new Vector2(moveInput.x, moveInput.y) * moveSpeed * Time.fixedDeltaTime;
        body.MovePosition(body.position + movement);
    }
    private void Shoot(){
        //if(controls.Player.Shoot.triggered)
        //{
            //Debug.Log("shoot");
            //GameObject bullet = BulletPoolManager.Instance.GetBullet();
        //}
        if(Input.GetKeyDown("space"))
        {
            Debug.Log("Shoot");
            GameObject bullet = BulletPoolManager.Instance.GetBullet();
            bullet.transform.position = gunTransform.position;
            bullet.transform.rotation = gunTransform.rotation;
        }
    }

    void Aim()
    {

    }

}