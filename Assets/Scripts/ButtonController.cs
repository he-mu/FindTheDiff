using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Camera Camera1;
    public Camera Camera2;
    public GameObject PivotPoint;

    public bool ZoomUpdating;
    public bool ChangeNeeded;

    public float TransitionTime = 1;
    public float FovStart1; //= 60;
    public float FovEnd1; // = 30;
    //public float FovStart2; // = 60;
    //public float FovEnd2; // = 30;

    public float _currentFov1;
    //private float _currentFov2;
    public float _lerpTime;
    //private Camera _camera;


    private void Start()
    {
        // Init start values
        _currentFov1 = Camera1.fieldOfView;
        FovStart1 = _currentFov1;
        FovEnd1 = _currentFov1;
        ZoomUpdating = false;
    }


    void Update()
    {
        ChangeFOV();
    }




    void ChangeFOV()
    {
        if (ChangeNeeded)
        {
            //If there is difference then run change
            if (Math.Abs(_currentFov1 - FovEnd1) > float.Epsilon)
            {
                ZoomUpdating = true;

                _lerpTime += Time.deltaTime;
                var t = _lerpTime / TransitionTime;

                //Different ways of interpolation if you comment them all it is just a linear lerp
                t = Mathf.SmoothStep(0, 1, t); //Mathf.SmoothStep() can be used just like Lerp, here it is used to calc t so it works with the other examples.
                                               //t = SmootherStep(t);
                                               //t = t * t;
                                               //t = t * t * t;

                _currentFov1 = Mathf.Lerp(FovStart1, FovEnd1, t);
            }

            else
            {
                ZoomUpdating = false;
                FovStart1 = _currentFov1;
                FovEnd1 = _currentFov1;
                _lerpTime = 0;
                ChangeNeeded = false;
            }

            //
            /*else if (Math.Abs(_currentFov1 - FovEnd1) < float.Epsilon)
            {
                //Just going back where we came from. For demonstrative purpos only ...
                _lerpTime = 0;
                Debug.Log("Switch");
                var tmp = FovStart1;
                FovStart1 = FovEnd1;
                FovEnd1 = tmp;
            }//*/

            Camera1.fieldOfView = _currentFov1;
            Camera2.fieldOfView = _currentFov1;
            
        }
    }


    private float SmootherStep(float t)
    {
        return t * t * t * (t * (6f * t - 15f) + 10f);
    }





    public void ButtonUpClick()
    {
        ChangeNeeded = true;

        if (!ZoomUpdating)
            ++FovEnd1;

        //Debug.Log("Button Up");

        //++Camera1.fieldOfView;
        //++Camera2.fieldOfView;
    }


    public void ButtonDownClick()
    {
        ChangeNeeded = true;

        if (!ZoomUpdating)
            --FovEnd1;


        //--Camera1.fieldOfView;
        //--Camera2.fieldOfView;
        //Debug.Log("Button Down");
    }


    public void ButtonRightClick()
    {
        Debug.Log("Button Right");
    }


    public void ButtonLeftClick()
    {
        Debug.Log("Button Left");
    }

}
