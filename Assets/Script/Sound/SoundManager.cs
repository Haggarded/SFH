using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip fire;
    public AudioClip dead;
    public AudioSource audioSource;
    public void PlayFire()
    {
        audioSource.PlayOneShot(fire);
    }
    public void PlayDead()
    {
        audioSource.PlayOneShot(dead);
    }
}
