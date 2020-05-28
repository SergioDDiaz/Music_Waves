using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    private int a = 0;
    public Camera cam1;
    public Camera cam2;
    // Start is called before the first frame update
    public void swcm(int x)
    {
        
 

        DesCam();
        if (a == 0)
        {
            cam1.enabled = true;
            a += x;
        }
        else if (a == 1)
        {
            cam2.enabled = true;
            a -= x;
        }
        

    }
    public void DesCam()
    {
        cam1.enabled = false;
        cam2.enabled = false;

    }
  }
