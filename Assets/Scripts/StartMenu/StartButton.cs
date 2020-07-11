using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton: MonoBehaviour
{
	public LevelLoader ll;
	Button start;

	private void Start()
	{
		start = gameObject.GetComponent<Button>();
		start.onClick.AddListener(() => ll.LoadLevel(2));

		if(!PlayerPrefs.HasKey("Started"))
		{
			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetInt("Started", 0);
			PlayerPrefs.SetInt("Song1", (int)music.none);
			PlayerPrefs.SetInt("Song2", (int)music.none);
			PlayerPrefs.SetInt("Song3", (int)music.none);
		}
	}
}
