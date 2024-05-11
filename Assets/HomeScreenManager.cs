using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToLevelSelect()
    {
        NavigationManager.Instance.NextLevel();
    }

    public void QuitApp()
    {
        NavigationManager.Instance.QuitApplication();
    }
}
