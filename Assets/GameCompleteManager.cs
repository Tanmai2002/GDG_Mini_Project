using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompleteManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject LevelCompleted;
    [SerializeField]
    GameObject LevelFailed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onLevelCompleted(float accuracy)
    {
        if (LevelFailed.activeSelf)
        {
            return;
        }
        LevelCompleted.SetActive(true);
        LevelCompleted.GetComponent<FinalPanelScript>().setStarForAccuracy(accuracy);
    }
    public void onLevelFailed()
    {
        LevelCompleted.SetActive(false);
        LevelFailed.SetActive(true);
    }
}
