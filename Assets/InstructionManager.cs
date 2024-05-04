using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> Instructions;
    public static InstructionManager instructionManager;
    [SerializeField]
    public TextMeshProUGUI instructionText;
    public float speed = 10f;
    public string currentInstruction;
    public bool isExecuting = false;
    bool nextInstruction = true;
    public Animator animator;
    bool hasExit = false;

    void Awake()
    {
        
        instructionManager = this;
    
    }
    void Start()
    {
        nextInstruction = true;
        isExecuting = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isExecuting && nextInstruction && Instructions.Count>0)
        {
            print(Instructions.Count);

            if (hasExit) {

                animator.SetBool("hasExit", false);
                hasExit = false;
            }
            StartCoroutine(streamInstruction());
            nextInstruction = false;
            
        }


    }

    IEnumerator streamInstruction()
    {
        isExecuting = true;
        foreach(char c in Instructions[0])
        {
            currentInstruction += c;
            instructionText.text = currentInstruction;
            yield return new WaitForSeconds(speed*Time.deltaTime);
        }
        isExecuting = false;
        
    }   

    public void enableChildren()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void disableChildren()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }


    public void exitScript()
    {
        Instructions.Clear();
        currentInstruction = "";
        instructionText.text = "";
        isExecuting = false;
        disableChildren();
    }

    public void NextInstruction()
    {
        if (isExecuting)
        {
            return;
        }
        if (Instructions.Count == 1)
        {
            Instructions.RemoveAt(0);
            animator.SetBool("hasExit", true);
            hasExit = true;
            nextInstruction = true;
            return;

        }

        if (Instructions.Count>0 && currentInstruction == Instructions[0])
        {
            Instructions.RemoveAt(0);
            currentInstruction = "";
            instructionText.text = "";
            isExecuting = false;
        }
        
        

        nextInstruction = true;
        
    }

    void addInstruction(string instruction)
    {
        Instructions.Add(instruction);
    }

    void addInstructions(List<string> instructions)
    {
        Instructions.AddRange(instructions);
    }   


}
