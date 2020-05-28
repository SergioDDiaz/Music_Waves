﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (AudioSource))]
public class Audio_V : MonoBehaviour
{
    AudioSource _audioSource;
    public static float[] _samples = new float[512];

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrum();
    }

    void GetSpectrum()
    {
        _audioSource.GetSpectrumData(_samples,0,FFTWindow.Blackman);
    }

}
