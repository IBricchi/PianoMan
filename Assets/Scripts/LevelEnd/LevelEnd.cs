using UnityEngine;
using System.Collections;

public class LevelEnd: MonoBehaviour
{
	public LevelLoader ll;
	private Settings settings;

	private void Awake()
	{
		settings = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>();
	}

	public void Collected(LevelEndDir dir)
	{
		switch (dir)
		{
			case LevelEndDir.up:
				break;
			case LevelEndDir.stay:
				break;
			case LevelEndDir.down:
				break;
			default:
				break;
		}

		settings.SaveSong();
		ll.LoadNextLevel();
	}
}
