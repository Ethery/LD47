using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class UIPage : MonoBehaviour
{

	public enum EState
	{
		Shown,
		Hidden
	}

	public UIManager.EPage Page;
	public EState CurrentState
	{
		get;
		private set;
	}
	private void Awake()
	{
		UIManager.RegisterPage(this);
	}

	private void OnDestroy()
	{
		UIManager.UnregisterPage(this);
	}

	public void Show(bool aShow)
	{
		CurrentState = aShow ? EState.Shown : EState.Hidden;
		gameObject.SetActive(aShow);
	}
}
