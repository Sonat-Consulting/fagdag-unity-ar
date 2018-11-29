using UnityEngine;
using System.Collections;

public class GameSound : MonoBehaviour {
	
	public AudioClip SoundEffect;
	
	public float Volume = 1;
	public float VolumeRange = 0;
	public float Pitch = 0;
	public float PitchRange = 0;
	
	public float Doppler;

    public bool Enabled = true;
	




	public static float DecibelToLinear(float value)
	{
       if (value == 0f)
           return 0f;
       else
           return Mathf.Pow(10f, value / 19.9315685693241f) / 65536f;
	}
	
	public static float DecibelToLinearLerp(float t, float start,float end)
	{
       float start_l = DecibelToLinear(start);
       float end_l   = DecibelToLinear(end);
       t = Mathf.Clamp01(t);
       return t * end_l + (1f - t) * start_l;
	}

	public static float DecibelLerpToLinear(float t, float start, float end)
	{
       t = Mathf.Clamp01(t);
       return DecibelToLinear(t * end + (1f - t) * start);
	}

	public static float LinearToDecibel(float value)
	{
       if (value == 0f)
           return 0f;
       else
           return (19.9315685693241f * Mathf.Log(65536f * value)) / Mathf.Log(10f);
	}



}
