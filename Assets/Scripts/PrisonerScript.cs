using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrisonerScript : MonoBehaviour
{
    [SerializeField]
    public int value;

    [SerializeField]
    public TextMesh Number;

    
    public NodeScript currentWaitingNode;
    Animator animator;
    Vector3 destination;
    float speed=10f;
    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (destination != transform.position)
        {
            destination = new Vector3(destination.x, destination.y, 2);
            // Move towards the destination using Lerp at constant Speed
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);


        }
        if(Vector3.Distance(transform.position, destination) < Time.deltaTime*speed)
        {
            destination = transform.position;
        }

    }

    public void prisonerToJailSimulation()
    {
        if(currentWaitingNode == null)
        {
            currentWaitingNode = LevelManager.levelManager.rootNode;
        }
        destination = currentWaitingNode.transform.position;

        StartCoroutine(MoveToDestinationAndAnimate());


    }


    public void prisonerToJailSimulationForRotation()
    {
        if (currentWaitingNode == null)
        {
            currentWaitingNode = LevelManager.levelManager.rootNode;
        }
        destination = currentWaitingNode.transform.position;

        StartCoroutine(MoveToDestinationAndAnimateForRotation());


    }



    IEnumerator MoveToDestinationAndAnimate()
    {
        // Move towards the destination
        while (transform.position != destination)
        {
            yield return null;
        }

        // Prisoner has reached the destination (jail), play animation
        PlayPrisonerAnimation();

        // Wait for the animation to finish
        yield return new WaitForSeconds(1f); // Adjust the time according to your animation's length
        UpdateLeftRightAnimBool(false);

        // Call another function after animation finishes
        CheckRunFunction();
    }

    IEnumerator MoveToDestinationAndAnimateForRotation()
    {
        // Move towards the destination
        while (transform.position != destination)
        {
            yield return null;
        }

        // Prisoner has reached the destination (jail), play animation
        PlayPrisonerAnimation();

        // Wait for the animation to finish
        yield return new WaitForSeconds(1f); // Adjust the time according to your animation's length
        UpdateLeftRightAnimBool(false);

        // Call another function after animation finishes
        CheckRunFunctionForRotation();
    }
    void UpdateLeftRightAnimBool(bool value)
    {
        animator.SetBool(name: "CheckLeftRight", value);
    }

    void PlayPrisonerAnimation()
    {
        // Play the animation here
        Debug.Log("Prisoner animation playing...");
        UpdateLeftRightAnimBool(true);
    }

    

    void CheckRunFunction()
    {
        if (currentWaitingNode.isPrisonOccupied())
        {
            NodeScript nextPrison = currentWaitingNode.getNextNode(this);
            currentWaitingNode= nextPrison;
            prisonerToJailSimulation();
            
        }
        else
        {
            LevelManager.levelManager.checkIfPrisonAssignedIsCorrect(currentWaitingNode);
        }
    }


    void CheckRunFunctionForRotation()
    {
        if (currentWaitingNode.isPrisonOccupied())
        {
            NodeScript nextPrison = currentWaitingNode.getNextNode(this);
            currentWaitingNode = nextPrison;
            prisonerToJailSimulationForRotation();

        }
        else
        {
            currentWaitingNode.assignPrisoner(this);
        }
    }

    public void runAway()
    {

        animator.Play("jump-thief");
        destination = new Vector3(100, 0, 0);
        LevelManager.levelManager.sendNextPrisonerIn();
       
    }

    public void assignNumber(int prisonerNumber)
    {
        value = prisonerNumber;

        Number.text = value.ToString();
    }
}
