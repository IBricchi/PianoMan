using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader: MonoBehaviour
{
	public Animator transition;
	public float tranistionTime = 1f;

	public void LoadLevel(int levelIndex)
	{
		StartCoroutine(LoadLevelCR(levelIndex));
	}

	public void LoadNextLevel()
	{
		StartCoroutine(LoadLevelCR(SceneManager.GetActiveScene().buildIndex + 1));
	}

	IEnumerator LoadLevelCR(int levelIndex)
	{
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(tranistionTime);

		SceneManager.LoadScene(levelIndex);
	}

}
