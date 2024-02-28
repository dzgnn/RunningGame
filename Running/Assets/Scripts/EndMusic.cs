using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class EndMusic : MonoBehaviour
{
    public PlayerController msc;
    private AudioSource Src;
    // Start is called before the first frame update
    void Start()
    {
        msc = GameObject.Find("Player").GetComponent<PlayerController>();
        Src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Stopping(){
        if (msc.gameOver == true)
       {
        Src.Pause();
       }
    }
}
