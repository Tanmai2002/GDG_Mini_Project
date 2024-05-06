using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationValidatorAndManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static RotationValidatorAndManager Instance;
    [SerializeField]
    NodeScript root;

    private void Awake()
    {
        Instance= this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRoationWeitghts()
    {
        Debug.Log("Updating Rotation Weights"); 
        root.UpdateWeitghts();

    }
}
