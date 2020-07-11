using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayMusic : MonoBehaviour
{
	public AudioSource musicPlayer;
	public AudioClip currentClip;

	public void ChangeClip(music id)
	{
		if (musicPlayer.isPlaying) musicPlayer.Stop();

		currentClip = Resources.Load<AudioClip>(songs.Get(id));
		musicPlayer.clip = currentClip;
		musicPlayer.Play();
	}
}
