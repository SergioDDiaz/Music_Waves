using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    public static GameObject cube;
    GameObject[] _sampleCube = new GameObject[512];
    public float _maxScale, prom, pdef;

    // Start is called before the first frame update
    void Start()
    {
        GameObject _instancesamplecube = (GameObject)Instantiate(_sampleCubePrefab);
        _instancesamplecube.transform.position = this.transform.position;
        _instancesamplecube.transform.parent = this.transform;
        _instancesamplecube.name = "SampleCube";
        cube = _instancesamplecube;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < 512; i++)
        {
            prom += Audio_V._samples[i];
        }
        pdef = prom / 512f;
        pdef = pdef * _maxScale;
        if (cube != null)
        {
            cube.transform.localScale = new Vector3(100, pdef, 100);
        }
        prom = 0; pdef = 0;
    }
}
