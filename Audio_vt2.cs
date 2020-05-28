using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Audio_vt2 : MonoBehaviour
{
    AudioSource _audioSource;
    public static float[] _samples = new float[512];
    public static float[] _freqBand = new float[8];
    public static float[] _bandBufffer = new float[8];
    float[] _bufferDecrease = new float[8];
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrum();
        MakeFrecBands();
        BandBuffer();
    }

    void GetSpectrum()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    void MakeFrecBands()
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }
            average /= count;
            _freqBand[i] = average * 10;
        }
    }
    void BandBuffer()
    {
        for( int b=0;b<8;b++)
        {
            if(_freqBand[b] > _bandBufffer[b])
            {
                _bandBufffer[b] = _freqBand[b];
                _bufferDecrease[b] = 0.005f;
            }
            if (_freqBand[b] < _bandBufffer[b])
            {
                _bandBufffer[b] -= _bufferDecrease[b];
                _bufferDecrease[b] *= 1.2f;
            }
        }
    }
}
