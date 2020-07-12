using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RestartButton: MonoBehaviour
{
	private Button reset;
	public LevelLoader ll;

	private void Start()
	{
		reset = gameObject.GetComponent<Button>();
		reset.onClick.AddListener(() =>
		{
			ll.LoadLevel(0);
		});
	}
}
