using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip collectedClip = null;
    public AudioClip audioClip = null;

    public AudioSource pickupSoundSource = null;
    public AudioSource worldSoundSource = null;

    // Start is called before the first frame update
    void Start()
    {
        worldSoundSource.Play();
    }
}
