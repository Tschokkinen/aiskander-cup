using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgMusic;
    public AudioSource move;
    public AudioSource win;
    public AudioSource lose;

    public void StopBgMusic()
    {
        bgMusic.Stop();
    }

    public void Move()
    {
        move.Play();
    }

    public void Win()
    {
        win.Play();
    }

    public void Lose()
    {
        lose.Play();
    }
}
