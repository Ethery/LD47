using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

#endif

public class Orienter : MonoBehaviour
{
#if UNITY_EDITOR

	[MenuItem("Tools/Orient Objects")]
	private static void DoIt()
	{
		foreach (Orienter or in FindObjectsOfType<Orienter>())
		{
			or.Orient();
		}
	}

#endif

	public void Orient()
	{
		Vector3 downDirection = (-transform.position).normalized;

		transform.rotation = Quaternion.LookRotation(Vector3.forward, -downDirection);
	}

	private void Awake()
	{
		Orient();
	}

	private void OnEnable()
	{
		Orient();
	}
}