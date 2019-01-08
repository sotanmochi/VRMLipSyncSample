using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInputSource : MonoBehaviour
{
	private AudioSource audioSource;

	void Start()
	{
		if(Microphone.devices.Length > 0)
		{
			audioSource = GetComponent<AudioSource>();
			audioSource.clip = Microphone.Start(null, true, 3, 44100);
			audioSource.loop = true;

			// Use the Attenuation of AudioMixer to mute microphone input.
			audioSource.mute = false;

			while((Microphone.GetPosition("") <= 0)){}
			audioSource.Play();
		}
	}

	void Update()
	{
		if(audioSource != null)
		{
			float volume = GetAveragedVolume();
			Debug.Log("Mic input volume: " + volume);
		}
	}

	float GetAveragedVolume()
	{ 
		float[] data = new float[256];
		float a = 0;
		audioSource.GetOutputData(data,0);
		foreach(float s in data)
		{
			a += Mathf.Abs(s);
		}
		return a / 256.0f;
	}
}
