using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPause()
    {
        AudioManager.instance.PlayPause();
        if(AudioManager.instance.isPaused )
        {

        }
        else
        {

        }
    }
}
