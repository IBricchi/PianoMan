using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(MusicField))]
public class MusicAttack: MonoBehaviour
{
	public GameObject musicField;
	public Movement mv;
	private MusicField mf;

	private Settings settings;

	private PlayMusic pm;

	public music attackID, attackID1, attackID2, attackID3;

	private bool attacking = false;
	private float attackingTime = 0f;
	public float maxAttackingTime = 10f;

	private bool outOfControl = false;
	private float outOfControlTime = 0f;
	public float maxOutOfControlTime = 10f;

	public float fieldRadiusIncrease = 2f;
	public float fieldRadiusDecrease = 5f;
	private float fieldRadius = 0f;
	private float maxFieldRadius = 10;

	private void Awake()
	{
		attackID1 = (music)PlayerPrefs.GetInt("Song1");
		attackID2 = (music)PlayerPrefs.GetInt("Song2");
		attackID3 = (music)PlayerPrefs.GetInt("Song3");
	}

	private void Start()
	{
		mf = gameObject.GetComponentInChildren<MusicField>();
		pm = gameObject.GetComponentInChildren<PlayMusic>();
		settings = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>();
	}

	private void FixedUpdate()
	{
		if(attacking)
		{
			AttackAnimation();
			attackingTime += Time.fixedDeltaTime;
			if(attackingTime > maxAttackingTime)
			{
				attacking = false;
				attackingTime = 0f;
				outOfControl = true;
			}
		}
		else if(outOfControl)
		{
			EndAttackAnimation();
			outOfControlTime += Time.fixedDeltaTime;
			if(outOfControlTime > maxOutOfControlTime)
			{
				outOfControl = false;
				outOfControlTime = 0f;
				GiveControl();
				pm.ChangeClip(settings.levelMusicId);
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
			{
				StartAttack(attackID1);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
			{
				StartAttack(attackID2);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
			{
				StartAttack(attackID3);
			}
		}
	}

	private void StartAttack(music id)
	{
		TakeControl();
		attacking = true;
		attackID = id;
		pm.ChangeClip(id);
		mf.SetFieldType(attackID);
	}
	private void TakeControl()
	{
		mv.TakeControl();
	}
	private void GiveControl()
	{
		mv.GiveControl();
	}

	private void AttackAnimation()
	{
		if(fieldRadius < maxFieldRadius)
		{
			fieldRadius += fieldRadiusIncrease * Time.fixedDeltaTime;
			musicField.transform.localScale = Vector2.one * fieldRadius;
		}
	}
	private void EndAttackAnimation()
	{
		if(fieldRadius > 0)
		{
			fieldRadius -= fieldRadiusDecrease * Time.fixedDeltaTime;
			musicField.transform.localScale = Vector2.one * fieldRadius;
		}
	}
}
