using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    private Meter meter;
    
    private bool firstTouch;

    public bool useTouch;

    void Start ()
    {
        meter = GameObject.Find("Meter").GetComponent<Meter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (firstTouch == false)
                {
                    meter.startMeter = true;
                    firstTouch = true;
                }
                else
                {
                    meter.stopped = true;
                }
            }
        }

        if (!useTouch)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (firstTouch == false)
                {
                    meter.startMeter = true;
                    firstTouch = true;
                }
                else
                {
                    meter.stopped = true;
                }
            }
        }
    }
}
