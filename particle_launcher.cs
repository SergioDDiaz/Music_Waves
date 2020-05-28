using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class particle_launcher : MonoBehaviour
{
    public ParticleSystem p_launcher;
    public GameObject cubito = instantiate.cube;
    public float _maxScale = 1000000f, prom, pdef, cond;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < 512; i++)
        {
            prom += Audio_V._samples[i];
        }
        pdef = prom / 512f;
        pdef = pdef * _maxScale;

        if (pdef > cond)
        {
            p_launcher.Emit(1);
        }
        prom = 0; pdef = 0;
    }
}
