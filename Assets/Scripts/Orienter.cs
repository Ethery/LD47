using UnityEditor;
using UnityEngine;

public class Orienter : MonoBehaviour
{
	[MenuItem("Tools/Orient Objects")]
	private static void DoIt()
	{
		foreach (Orienter or in FindObjectsOfType<Orienter>())
		{
			or.Orient();
		}
	}

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