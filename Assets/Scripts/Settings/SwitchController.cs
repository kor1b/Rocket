using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class SwitchController : EventTrigger {

	AudioManager audioManager;
	Sound s;
	HandleColor handleColor;

	Slider slider;

	private void Start()
	{
		audioManager = FindObjectOfType<AudioManager>();
		slider = GetComponent<Slider>();
		handleColor = GetComponentInChildren<HandleColor>();
	}

	public void Play_PauseMusic(string audioName)
	{
		s = Array.Find(audioManager.sounds, sound => sound.name == audioName);
		if (s.source.isPlaying)
		{
			s.source.enabled = false;
			slider.value = 0;
		}
		else
		{
			s.source.enabled = true;
			slider.value = 1;
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
			}
			else
			{
				audioManager.sounds[i].source.enabled = true;
				slider.value = 1;
			}
			handleColor.ChangeColor();
			audioManager.sounds[i].source.Stop();
		}
	}
	}

