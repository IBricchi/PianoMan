using UnityEngine;
using System.Collections;

public class LevelEnd: MonoBehaviour
{
	public LevelLoader ll;
	public Settings settings;

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
