using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class NodeScript : MonoBehaviour
{
    [SerializeField]
    Image image;

    PrisonerScript captured_prisoner;

    
    NodeScript left;
    NodeScript right;

    public int level;

   
    void Start()
    {
        int max_level = LevelManager.levelManager.max_level;
        float spacing = 50 * math.pow(2, max_level - 1);
        captured_prisoner = null;
        left=null; right=null;
        if (this.level < max_level)
        {
            Vector3 pos=transform.GetComponent<RectTransform>().anchoredPosition;
            
            GameObject left_node=Instantiate(gameObject, new Vector3(pos.x-spacing, pos.y-50, pos.z), Quaternion.identity,gameObject.transform.parent.transform);
            left=left_node.GetComponent<NodeScript>();
            left.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
            left.GetComponent<RectTransform>().anchoredPosition= new Vector3(pos.x - spacing/(math.pow(2,level)), pos.y - 50*(3-level), pos.z);

            left.level = level+1;
            GameObject right_node=Instantiate(gameObject,new Vector3(pos.x+50,pos.y-50,pos.z), Quaternion.identity, gameObject.transform.parent.transform);
            right=right_node.GetComponent<NodeScript>();

            right.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            right.GetComponent<RectTransform>().anchoredPosition = new Vector3(pos.x + spacing / (math.pow(2, level)), pos.y - 50*(3-level), pos.z);
            right.level = level+1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cellSelection()
    {
        LevelManager.levelManager.userSelectedPrison(this);
    }
    public void updateColorAsCorrect()
    {
        image.color = Color.green;
    }
    public void updateColorAsSelected()
    {
        image.color = Color.yellow;
    }

    public void updateColorAsUnSelected()
    {
        image.color = Color.white;
    }

    public void updateColorAsWrong()
    {
        image.color = Color.red;
    }

    public bool isEmpty()
    {
        return captured_prisoner == null;
    }

    public void assignPrisoner(PrisonerScript prisoner)
    {
        captured_prisoner = prisoner;
        

    }
    public NodeScript getNextNode(PrisonerScript prisoner)
    {
        if(prisoner.value>captured_prisoner.value)
        {
            return right;
        }
        else
        {
            return left;
        }

    }
    public bool isPrisonOccupied()
    {
        return captured_prisoner!=null; 
    }
    
    public PrisonerScript getPrisoner()
    {
        return captured_prisoner;
    }

}
