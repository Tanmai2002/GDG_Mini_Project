using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    MeshRenderer Heart1;
    [SerializeField]
    MeshRenderer Heart2;
    [SerializeField]
    MeshRenderer Heart3;
    int lifeCount=3;
    void Start()
    {
        Heart1.material.color = Color.red;
        Heart2.material.color = Color.red;
        Heart3.material.color = Color.red;

    }

    public void lifeLost()
    {
        if(lifeCount == 0)
        {
            GameManager.Instance.onLevelFailed();
            return;
        }
        if(lifeCount == 1)
        {
            GameManager.Instance.onLevelFailed();
            Heart1.material.color = Color.gray;
        }
        if(lifeCount == 2)
        {
            Heart2.material.color = Color.gray;
        }

        if(lifeCount==3)
        {
            Heart3 .material.color = Color.gray;
        }
        lifeCount--;
    }

}
