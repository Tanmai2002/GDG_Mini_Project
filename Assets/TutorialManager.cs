using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool isCompleted = false;
    [SerializeField]
    List<string> list;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!RotationValidatorAndManager.Instance.isBalanced() && !isCompleted && list.Count>0)
        {
            InstructionManager.instructionManager.addInstructions(list);
            isCompleted = true;

        }
        
    }
}
