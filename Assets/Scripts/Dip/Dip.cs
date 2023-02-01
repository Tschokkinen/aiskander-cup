using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dip : MonoBehaviour
{
    private Animator anim;
    private AudioManager audioManager;

    private bool gotKey;
    private bool win;

    // Start is called before the first frame update
    void Start()
    { 
        anim = GetComponent<Animator>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void MoveInWater(float arrowPosition)
    {
        if (arrowPosition >= 0.12f && arrowPosition <= 1.68f)
        {
            if (!gotKey)
            {
                if (!anim.GetBool("Stairs"))
                {
                    anim.SetBool("Stairs", true);
                }
                else if (!anim.GetBool("InWater"))
                {
                    anim.SetBool("InWater", true);
                }
                else if (!anim.GetBool("Swim"))
                {
                    anim.SetBool("Swim", true);
                    gotKey = true;
                }
            }
            else
            {
                if (!anim.GetBool("InWaterKey"))
                {
                    anim.SetBool("InWaterKey", true);
                }
                else if (!anim.GetBool("StairsKey"))
                {
                    anim.SetBool("StairsKey", true);
                }
                else if (!anim.GetBool("IdleKey"))
                {
                    anim.SetBool("IdleKey", true);
                    audioManager.StopBgMusic();
                    win = true;
                    bool doubleStopped = GameObject.Find("Meter").GetComponent<Meter>().doubleStopped = true;
                    bool meter = GameObject.Find("Meter").GetComponent<Meter>().stopped = true;
                }
            }
        }
        /*
        else if (arrowPosition < -1.8f)
        {
            Debug.Log("Reverse");
            anim.SetTrigger("Idle");
        }
        */
        else
        {
            if (!gotKey)
            {
                if (anim.GetBool("InWater"))
                {
                    anim.SetBool("InWater", false);
                }
                else if (anim.GetBool("Stairs"))
                {
                    anim.SetBool("Stairs", false);
                }
                else if (anim.GetBool("Swim"))
                {
                    anim.SetBool("Swim", false);
                }
            }
            else
            {
                if (anim.GetBool("StairsKey"))
                {
                    anim.SetBool("StairsKey", false);
                }
                else if (anim.GetBool("InWaterKey"))
                {
                    anim.SetBool("InWaterKey", false);
                }

            }
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
