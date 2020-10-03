using UnityEngine;
using UnityEditor;


public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	public static T Instance { get { return s_instance; } }
	public static bool IsInstanced { get { return s_instance != null; } }

	private static T s_instance = null;
	#region Private

	protected virtual void Awake()
	{
		if (!IsInstanced)
		{
			s_instance = this as T;

			if (transform.parent == null)
			{
				DontDestroyOnLoad(this);
			}
		}

		if (s_instance != this)
		{
			Destroy(this);
		}
	}

	protected virtual void OnDestroy()
	{
		if (s_instance == this)
		{
			s_instance = null;
		}
	}

	#endregion
}