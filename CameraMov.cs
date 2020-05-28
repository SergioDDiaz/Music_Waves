using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hola
public class CameraMov : MonoBehaviour
{
    public float speed;


    void FixedUpdate()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
