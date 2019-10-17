using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetComponent : MonoBehaviour
{
	public GameObject TargetObject;

	private void Update()
	{
		if (TargetObject == null)
		{
			Destroy(this);
		}
	}
}
