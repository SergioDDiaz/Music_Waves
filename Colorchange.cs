using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colorchange : MonoBehaviour
{
    
    Renderer rend_Renderer;
    Vector3 cube;
    float scl = 1.0f;
    float h=0.5f, s=1.0f, v=1.0f;
    Vector3 Poscube;
    // Start is called before the first frame update
    void Start()
    {

        cube = gameObject.GetComponent<Transform>().localScale;
        Poscube = gameObject.GetComponent<Transform>().position;
        rend_Renderer = GetComponent<Renderer>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float Ht;
        Ht = h;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            print("Arriba   ");
            cube.y += 0.4f;
            if (h < 1 && h >= 0.0001)
            {
                h += 0.01f;
            }
            if (h > 1)
                h = 0.999f;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            print("Abajo");
            cube.y -= 0.4f;
            if (h < 1 && h >= 0.0001)
            {
                h -= 0.01f;
            }
            if (h < 1)
                h = 0.999f;


        }


        rend_Renderer.material.color = Color.HSVToRGB(h, s, v);
        gameObject.GetComponent<Transform>().localScale = cube;
}
}
