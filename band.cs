using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class band : MonoBehaviour
{
    Renderer rend_Renderer;
    public int _band;
    public float _startScale, _scaleMultiplier;
    public bool _useBuffer;
    float h = 0.5f, s = 1.0f, v = 1.0f;
    float scl = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rend_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (Audio_vt2._bandBufffer[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
            h = (Audio_vt2._bandBufffer[_band])/5;
            s = _scaleMultiplier / 8;
        }
        if(!_useBuffer)
        { 
            transform.localScale = new Vector3(transform.localScale.x,(Audio_vt2._freqBand[_band]*_scaleMultiplier)+_startScale,transform.localScale.z);
            h = (Audio_vt2._freqBand[_band])/5;
        }
        rend_Renderer.material.color = Color.HSVToRGB(h, s, v);

        s = _scaleMultiplier / 8;
    }
}
