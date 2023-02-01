using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Throw : MonoBehaviour
{
    private Animator anim;
    private AudioManager audioManager;

    private bool win;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void ThrowBall (float arrowPosition)
    {
        audioManager.StopBgMusic();

        Debug.Log(arrowPosition);
        if (arrowPosition >= 0.12f && arrowPosition <= 1.68f)
        {
            anim.SetTrigger("Throw");
            win = true;
        }
        else if (arrowPosition < -1.8f)
        {
            anim.SetTrigger("ThrowShort");
        }
        else
        {
            anim.SetTrigger("ThrowMiss");
            win = false;
        }
    }

    public void PlayAudio()
    {
        if (win)
        {
            audioManager.Win();
        }
        else
        {
            audioManager.Lose();
        }
    }

    private void PlayMoveEffect()
    {
        audioManager.Move();
    }
}
