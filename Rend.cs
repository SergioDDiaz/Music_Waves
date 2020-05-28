using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rend : MonoBehaviour
{
    public GameObject ojeto1;
    public GameObject ojeto2;
    public GameObject ojeto3;

    public void enable()
    {
        ojeto1.SetActive(true);
        ojeto2.SetActive(true);
        ojeto3.SetActive(true);
    }
    public void disable()
    {
        ojeto1.SetActive(false);
        ojeto2.SetActive(false);
        ojeto3.SetActive(false);
    }
}
