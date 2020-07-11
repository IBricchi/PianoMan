using UnityEngine;
using System.Collections;

public class Settings: MonoBehaviour
{
	public music levelMusicId;
	public GameObject player;
	private PlayMusic pm;

	private void Start()
	{
		pm = player.GetComponentInChildren<PlayMusic>();
		pm.ChangeClip(levelMusicId);
	}
}
