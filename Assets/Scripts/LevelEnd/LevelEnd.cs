using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
		PlayerPrefs.SetInt("NL", SceneManager.GetActiveScene().buildIndex + 1);
		ll.LoadNextLevel();
	}
}
