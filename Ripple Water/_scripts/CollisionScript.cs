using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {
	public Vector3[] _places = new Vector3[9];
	public float _startScale, _scaleMultiplier;
	public int waveNumber;
	public float distanceX, distanceZ;
	public float[] waveAmplitude;
	public float magnitudeDivider;
	public Vector2[] impactPos;
	public float[] distance;
	public Vector2[] _Offset;
	public float speedWaveSpread,centerscale,sizeI;

	Mesh mesh;
	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshFilter>().mesh;
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 9; i++)
		{



			distance[i] = 0;
			waveAmplitude[i] = 0;
			distanceX = (this.transform.position.x - _places[i].x);
			distanceZ = (this.transform.position.z - _places[i].z);
			impactPos[i].x = _places[i].x;
			impactPos[i].y = _places[i].z;
			waveNumber = i + 1;



			GetComponent<Renderer>().material.SetFloat("_xImpact" + waveNumber, impactPos[i].x);
			GetComponent<Renderer>().material.SetFloat("_zImpact" + waveNumber, impactPos[i].y);

			_Offset[waveNumber - 1].x = ((distanceX)/(sizeI * 2.5f));
			_Offset[waveNumber - 1].y = ((distanceZ)/(sizeI * 2.5f));
			GetComponent<Renderer>().material.SetFloat("_OffsetX" + waveNumber, _Offset[waveNumber - 1].x);
			GetComponent<Renderer>().material.SetFloat("_OffsetZ" + waveNumber, _Offset[waveNumber - 1].y);

			if (waveNumber <= 8)
			{
				GetComponent<Renderer>().material.SetFloat("_WaveAmplitude" + waveNumber, ((Audio_vt2._freqBand[i] * _scaleMultiplier) + _startScale) * magnitudeDivider);
			}
			if (waveNumber == 9)
			{
				GetComponent<Renderer>().material.SetFloat("_WaveAmplitude" + waveNumber, ((Audio_vt2._AmplitudeBuffer * _scaleMultiplier) + _startScale) * magnitudeDivider * centerscale);
			}

			waveAmplitude[i] = GetComponent<Renderer>().material.GetFloat("_WaveAmplitude" + (i + 1));
			if (waveAmplitude[i] > 0)
			{
				distance[i] += speedWaveSpread;
				GetComponent<Renderer>().material.SetFloat("_Distance" + (i + 1), distance[i]);
				GetComponent<Renderer>().material.SetFloat("_WaveAmplitude" + (i + 1), waveAmplitude[i] * 0.98f);
			}
			if (waveAmplitude[i] < 0.01)
			{
				GetComponent<Renderer>().material.SetFloat("_WaveAmplitude" + (i + 1), 0);
				distance[i] = 0;
			}

		}
	}

	
}
