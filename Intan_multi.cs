using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intan_multi : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    GameObject[] _sampleCube = new GameObject[512];
    public float _maxScale;

    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < 512; i++)
        {
            if (_sampleCube != null)
            {
                _sampleCube[i].transform.localScale = new Vector3(10, (Audio_V._samples[i] * _maxScale) + 2, 10);
            }

        }
    }
}
