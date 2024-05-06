using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelGridScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int TotalLevels;
    void Start()
    {
        float startx = -200;
        float starty = 100;
        float x = startx;
        float y = starty;

        for (int i = 1; i <= TotalLevels; i++)
        {
            if((i-1)%5==0)
            {
                x = startx;
                y -= 100;
            }
            GameObject obj = Instantiate(Resources.Load("Level1")) as GameObject;
            obj.transform.SetParent(this.transform);
            obj.transform.localScale = new Vector3(1, 1, 1);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
            obj.transform.localPosition = new Vector3(x, y, 0);
            x += 100;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
