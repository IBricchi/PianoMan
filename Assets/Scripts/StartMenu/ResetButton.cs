using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
	private Button reset;

	private void Start()
	{
		reset = gameObject.GetComponent<Button>();
		reset.onClick.AddListener(() => PlayerPrefs.DeleteAll());
	}
}
