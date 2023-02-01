using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meter : MonoBehaviour
{
    private string sceneName;

    private Throw throwBall;
    private Dip dip;

    public GameObject arrow;

    public bool startMeter;

    private bool leftAndRight = true; //whether we are moving up or down
    public bool stopped = false;    //whether we have stopped or not
    public bool doubleStopped = false;

    [SerializeField]private float upSpeed;    //our upwards movement speed
    [SerializeField]private float downSpeed;    //our downwards movement speed
    [SerializeField]private float maxRight;    //the max height at which we will change direction
    [SerializeField]private float minLeft;    //the min height at which we will change direction
    [SerializeField]private float minWinHeight;    //the minimum height we must be at to win
    [SerializeField]private float maxWinHeight;    //the maximum height we must be at to win
 
    void Start ()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Basketball")
        {
            throwBall = GameObject.Find("Throw").GetComponent<Throw>(); 
        }
        else if (sceneName == "Dip")
        {
            dip = GameObject.Find("Player").GetComponent<Dip>();
        }
    }

    void Update () 
    {
        if (startMeter)
        {
            if (stopped)
            {
                Stopped();
            }
            else if(!stopped)
            { 
                MoveLeftRight ();
            }
        }
    }
 
    void MoveLeftRight()
    {
        if (leftAndRight) 
        {    
            arrow.transform.Translate (Vector3.right * Time.deltaTime / upSpeed);  
            if (arrow.transform.localPosition.x > maxRight) 
            {    
                leftAndRight = false;   
            }
        } 
        else 
        {    
            arrow.transform.Translate (Vector3.right * Time.deltaTime / -downSpeed);  
            if (arrow.transform.localPosition.x < minLeft) 
            {    
                leftAndRight = true; 
            }
        }
    }
 
 
    void Stopped()  
    {
        float arrowPosition = arrow.transform.localPosition.x;

        if (sceneName == "Basketball")
        {
            throwBall.ThrowBall(arrowPosition);
        }
        else if (sceneName == "Dip")
        {
            Debug.Log("Dip");
            dip.MoveInWater(arrowPosition);
            if (!doubleStopped) stopped = false;
        }
    }
}
