using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPanelScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    MeshRenderer Star1;
    [SerializeField]
    MeshRenderer Star2;
    [SerializeField]
    MeshRenderer Star3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setStarForAccuracy(float accuracy)
    {
        if(accuracy > 0.98f)
        {
            Star3.material.color = Color.yellow;
        }

        if (accuracy > 0.8f)
        {
            Star2.material.color = Color.yellow;
        }
        Star1.material.color = Color.yellow;
    }

    public void NextLevel()
    {
        NavigationManager.Instance.NextLevel();

    }

    public void HomeScreen()
    {
        NavigationManager.Instance.GoHome();

    }

    public void RetryLevel()
    {
        NavigationManager.Instance.PlayAgain();

    }
}
