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

    float[] _freqBandHighest = new float[8];
    public static float[] _audioband = new float[8];
    public static float[] _audiobandBuffer = new float[8];

    public static float _Amplitude, _AmplitudeBuffer;

    float _AmplitudeHighest;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        for (int i = 0; i < 8; i++)
        {
            _freqBandHighest[i] = 0.00000000000001f;
            _AmplitudeHighest = 0.00000000000001f;
        }
    }

        // Update is called once per frame
        void Update()
    {
        GetSpectrum();
        MakeFrecBands();
        BandBuffer();
        CreateAudiobands();
        GetAmplitude();
    }

    void CreateAudiobands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (_freqBand[i] > _freqBandHighest[i])
            {
                _freqBandHighest[i] = _freqBand[i];
            }
         
                _audioband[i] = (_freqBand[i] / _freqBandHighest[i]);
                _audiobandBuffer[i] = (_bandBufffer[i] / _freqBandHighest[i]); 
        }
       
    } 
    void GetAmplitude()
    {
        float _currentAmplitude = 0;
        float _currentAmplitudeBuffer = 0;
        for (int i = 0; i < 8; i++)
        {
            _currentAmplitude += _audioband[i];
            _currentAmplitudeBuffer += _audiobandBuffer[i];
        }
        if(_currentAmplitude > _AmplitudeHighest)
        {
            _AmplitudeHighest = _currentAmplitude;
        }
        if (_AmplitudeHighest != 0)
        {
            _Amplitude = _currentAmplitude / _AmplitudeHighest;
            _AmplitudeBuffer= _currentAmplitudeBuffer / _AmplitudeHighest;
        }
       
    }   


    void BandBuffer()
    {
        for( int b=0;b<8;b++)
        {
            if(_freqBand[b] > _bandBufffer[b])
            {
                _bandBufffer[b] = _freqBand[b];
                _bufferDecrease[b] = _bandBufffer[b]*0.05f;
            }
            if (_freqBand[b] < _bandBufffer[b])
            {
                _bandBufffer[b] -= _bufferDecrease[b];
                _bufferDecrease[b] *= 1.2f;
            }
        }
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
                average += _samples[count] * (count + 1f);
                count++;
            }
            average /= count;
            _freqBand[i] = average * 10f;
        }
    }
  


    

}
