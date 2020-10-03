using UnityEngine;

public class UIPage : MonoBehaviour
{
	public enum EState
	{
		Shown,
		Hidden
	}

	public UIManager.EPageType PageType;

	[SerializeField]
	private EState m_CurrentState;

	public EState CurrentState => m_CurrentState;

	public GameObject Content;

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
		m_CurrentState = aShow ? EState.Shown : EState.Hidden;
		Content.SetActive(aShow);
	}
}