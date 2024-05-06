using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelSectionScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public TextMeshProUGUI Text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnThisLevelClicked()
    {
        NavigationManager.Instance.LoadLevel(int.Parse(Text.text));
    }
}
