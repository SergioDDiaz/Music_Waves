using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    private int a = 0;
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public GameObject Thorus;

    // Start is called before the first frame update
    public void swcm(int x)
    {
        Thorus.SetActive(true);
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

    public void Rwaves()
    {

        DesCam();
        Thorus.SetActive(false);
        cam3.enabled = true;
    }
        public void DesCam()
    {
        cam1.enabled = false;
        cam2.enabled = false;
        cam3.enabled = false;
    }
  }
