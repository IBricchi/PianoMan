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
	}
}
