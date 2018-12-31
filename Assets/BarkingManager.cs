using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class BarkingManager : MonoBehaviour
{
   
    public AudioClip[] Barks = new AudioClip[5];
    public AudioSource BarkAS;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   public void Bark()
    {
        BarkAS.clip = Barks[Random.Range(0, 4)];
       if(!BarkAS.isPlaying) BarkAS.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
