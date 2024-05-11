using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int HomeScreenIndex= 0;
    public static int LevelSelecterIndex = 1;
    public static NavigationManager Instance; 

    private void Awake()
    {
       if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void GoHome()
    {
        SceneManager.LoadScene(HomeScreenIndex);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        int index= (SceneManager.GetActiveScene().buildIndex + 1) ;
        SceneManager.LoadScene(index);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index+LevelSelecterIndex);
    }

    
    public void QuitApplication()
    {
        Application.Quit();
    }
}
