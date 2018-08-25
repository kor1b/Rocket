using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class SwitchController : EventTrigger {

	AudioManager audioManager;
	Sound s;
	HandleColor handleColor;

	Slider slider;

	static float musicValue = 1;
	static float soundsValue = 1;

	private void Awake()
	{
		audioManager = FindObjectOfType<AudioManager>();
		slider = GetComponent<Slider>();
		handleColor = GetComponentInChildren<HandleColor>();
		if (name == "Music")
			slider.value = musicValue;
		else if (name == "Sounds")
			slider.value = soundsValue;
	}

	private void FixedUpdate()
	{
		handleColor.ChangeColor();
	}

	public void Play_PauseMusic(string audioName)
	{
		s = Array.Find(audioManager.sounds, sound => sound.name == audioName);
		if (s.source.isPlaying)
		{
			s.source.enabled = false;
			slider.value = 0;
			musicValue = slider.value;
		}
		else
		{
			s.source.enabled = true;
			slider.value = 1;
			musicValue = slider.value;
		}
		handleColor.ChangeColor();
	}

	public void Play_PauseSounds(int firstElement)
	{
		for (int i = firstElement; i < audioManager.sounds.Length; i++) {
			if (audioManager.sounds[i].source.enabled)
			{
				audioManager.sounds[i].source.enabled = false;
				slider.value = 0;
				soundsValue = slider.value;
			}
			else
			{
				audioManager.sounds[i].source.enabled = true;
				slider.value = 1;
				soundsValue = slider.value;
			}
			handleColor.ChangeColor();
			audioManager.sounds[i].source.Stop();
		}
	}
	}

