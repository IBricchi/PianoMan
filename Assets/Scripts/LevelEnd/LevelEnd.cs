using UnityEngine;
using System.Collections;

public class LevelEnd: MonoBehaviour
{
	public LevelLoader ll;

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

		ll.LoadNextLevel();
	}
}
