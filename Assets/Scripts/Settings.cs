using UnityEngine;
using System.Collections;

public class Settings: MonoBehaviour
{
	public music levelMusicId;
	public GameObject player;
	private PlayMusic pm;

	public bool hasSong1, hasSong2, hasSong3;
	private bool currentSongIn1 = false, currentSongIn2 = false, currentSongIn3 = false;

	private void Start()
	{
		pm = player.GetComponentInChildren<PlayMusic>();
		pm.ChangeClip(levelMusicId);

		hasSong1 = PlayerPrefs.HasKey("Song1");
		hasSong2 = PlayerPrefs.HasKey("Song2");
		hasSong3 = PlayerPrefs.HasKey("Song3");

		if (hasSong1) currentSongIn1 = PlayerPrefs.GetInt("Song1") == (int)levelMusicId;
		if (hasSong2) currentSongIn2 = PlayerPrefs.GetInt("Song2") == (int)levelMusicId;
		if (hasSong3) currentSongIn3 = PlayerPrefs.GetInt("Song2") == (int)levelMusicId;
	}

	public void SaveSong()
	{
		if(!(currentSongIn1 || currentSongIn2 || currentSongIn3))
		{
			if(hasSong1 && hasSong2 && hasSong3)
			{
				int lostSong = Random.Range(0, 3);
				switch(lostSong){
					case 0:
						hasSong1 = false;
						break;
					case 1:
						hasSong2 = false;
						break;
					case 3:
						hasSong3 = false;
						break;
					default:
						hasSong1 = false;
						break;
				}
			}

			if(!hasSong1)
			{
				PlayerPrefs.SetInt("Song1", (int)levelMusicId);
			}
			else if(!hasSong2)
			{
				PlayerPrefs.SetInt("Song2", (int)levelMusicId);
			}
			else if(!hasSong3)
			{
				PlayerPrefs.SetInt("Song3", (int)levelMusicId);
			}
		}
	}
}
