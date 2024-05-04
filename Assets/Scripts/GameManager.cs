using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance =this;
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

    public void onGameCompleted(float accuracy)
    {
        FindObjectOfType<GameCompleteManager>().GetComponent<GameCompleteManager>().onLevelCompleted(accuracy);
        
    }

    public void onLevelFailed()
    {
        FindAnyObjectByType<GameCompleteManager>().GetComponent<GameCompleteManager>().onLevelFailed();

    }
}
