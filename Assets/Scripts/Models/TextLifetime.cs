using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLifetime : MonoBehaviour
{
	public float LifeTime;
	// Start is called before the first frame update
	private void Awake()
	{
		Destroy(gameObject, LifeTime);
	}
}
