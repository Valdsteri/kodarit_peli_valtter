using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Master controls;
    
    public GameObject pausetext;

    public gameStates currentGameState;
    // Start is called before the first frame update

    void Awake ()
    {
        controls = new Master ();
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsGamePlay()
    {
        return currentGameState == gameStates.Gameplay;
    }
}
