using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static LevelManager levelManager;
    public int max_level;
    [SerializeField]
    Transform PrisonerSpawnLocation;

    [SerializeField]
    GameObject PrisonerObject;
    [SerializeField]
    List<int> prisonerNumbers=new List<int>();

    private NodeScript currentSelection;
    private PrisonerScript currentPrisoner;
    public NodeScript rootNode;

    private void Awake()
    {
        levelManager = this;
        if(prisonerNumbers.Count == 0)
        {
            //Adding 10 random unique numbers
            for (int i = 0; i < 10; i++)
            {
                int random = Random.Range(1, 100);
                while (prisonerNumbers.Contains(random))
                {
                    random = Random.Range(1, 100);
                }
                prisonerNumbers.Add(random);
            }
        }   
        SpawnPrisoner();
        

        

    }
    void SpawnPrisoner()
    {
        GameObject Prisoner= Instantiate(PrisonerObject, PrisonerSpawnLocation.position, Quaternion.identity);
        Prisoner.GetComponent<PrisonerScript>().assignNumber( prisonerNumbers[0]);
        
        prisonerNumbers.RemoveAt(0);
        currentPrisoner = Prisoner.GetComponent<PrisonerScript>();  

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void userSelectedPrison(NodeScript s)
    {
        if(currentSelection != null)
        {
            currentSelection.updateColorAsUnSelected();
        }
        currentSelection = s;
        s.updateColorAsSelected();
        currentPrisoner.prisonerToJailSimulation();

    }

    public async void checkIfPrisonAssignedIsCorrect(NodeScript prison)
    {
        if (currentSelection == prison)
        {
            currentSelection.updateColorAsCorrect();
            prison.assignPrisoner(currentPrisoner);
            //Run Prison Animation

            SpawnPrisoner();

            

        }
        else
        {
            currentSelection.updateColorAsWrong();
            currentPrisoner.runAway();

        }
        currentSelection.updateColorAsUnSelected();

    }


    public void sendNextPrisonerIn()
    {
        SpawnPrisoner();
    }


}
