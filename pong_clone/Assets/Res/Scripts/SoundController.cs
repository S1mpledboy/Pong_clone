using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource ballSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.ballSound.Play();
    }
}
