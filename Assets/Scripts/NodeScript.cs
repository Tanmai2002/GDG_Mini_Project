using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    int left_weight=0;
    int righth_weight=0;

   
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
    public void cellSelectionWithRotation()
    {

        Debug.Log("Cell Selection With Rotation");
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
        if (RotationValidatorAndManager.Instance != null)
        {

        RotationValidatorAndManager.Instance.UpdateRoationWeitghts();
        }
        

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


   // -------------------------------------Rotation Functions-------------------------------------------------------
    public int UpdateWeitghts()
    {

        Debug.Log("Updating Weights");
        if (captured_prisoner == null)
        {
            return 0;
        }
        if(left==null && right==null)
        {
            return 1;
        }
        left_weight= left.UpdateWeitghts();
        righth_weight= right.UpdateWeitghts();
        TextMeshProUGUI[] values=GetComponentsInChildren<TextMeshProUGUI>();
        foreach(TextMeshProUGUI value in values)
        {
            if(value!= null)
            {
                if (value.gameObject.name == "left_weight")
                {
                    value.text = left_weight.ToString();
                }else if(value.gameObject.name == "right_weight")
                {
                    value.text = righth_weight.ToString();
                }
            }
        }

        Debug.Log("Values: "+left_weight+" "+righth_weight);
        return 1+math.max(left_weight,righth_weight);
        
    }
    

    IEnumerator simulateAllChildPrisonerForLeftRotation(NodeScript parent)
    {

        yield return new WaitForSeconds(2);

        while (this.captured_prisoner != null)
        {
            captured_prisoner.currentWaitingNode = parent;
            captured_prisoner.prisonerToJailSimulationForRotation();
            captured_prisoner = null;
            yield return new WaitForSeconds(2);
            StartCoroutine(left.simulateAllChildPrisonerForLeftRotation(parent));
            StartCoroutine(right.simulateAllChildPrisonerForLeftRotation(parent));
        }


    }

    public void RotateLeft()
    {
        if (math.abs(left_weight - righth_weight) <= 1)
        {
            InstructionManager.instructionManager.addInstruction("Cant Rotate Left as it is Balanced");
            return;
        }
        if (righth_weight-left_weight<=0)
        {
            InstructionManager.instructionManager.addInstruction("Thats Not How you do it!");
            return;
        }
        if (left.captured_prisoner==null)
        {
            captured_prisoner.currentWaitingNode = left;
            captured_prisoner.prisonerToJailSimulationForRotation();
            captured_prisoner= null;
            if(right.left.captured_prisoner!=null && right.right.captured_prisoner==null)
            {
                right.left.captured_prisoner.currentWaitingNode = this;
                right.left.captured_prisoner.prisonerToJailSimulationForRotation();
                right.left.captured_prisoner = null;

                
            }
            StartCoroutine(right.simulateAllChildPrisonerForLeftRotation(this));


        }
        else
        {

            
        }

    }


    public void RotateRight()
    {
        if (math.abs(left_weight - righth_weight) <= 1)
        {
            InstructionManager.instructionManager.addInstruction("Cant Rotate Left as it is Balanced");
            return;
        }
        if (left_weight - righth_weight <= 0)
        {
            InstructionManager.instructionManager.addInstruction("Thats Not How you do it!");
            return;
        }
        if (right.captured_prisoner == null)
        {
            captured_prisoner.currentWaitingNode = right;
            captured_prisoner.prisonerToJailSimulationForRotation();
            captured_prisoner = null;
            if (left.right.captured_prisoner != null && left.left.captured_prisoner == null)
            {
                left.right.captured_prisoner.currentWaitingNode = this;
                left.right.captured_prisoner.prisonerToJailSimulationForRotation();
                left.right.captured_prisoner = null;


            }
            StartCoroutine(left.simulateAllChildPrisonerForLeftRotation(this));


        }
        else
        {


        }

    }
}
