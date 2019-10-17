using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedComponent : MonoBehaviour
{
	public float MaxSpeed;
	[HideInInspector] public float CurrentSpeed;

    void Start()
    {
		CurrentSpeed = MaxSpeed;
    }
    void Update()
    {
		if (CurrentSpeed > MaxSpeed)
			CurrentSpeed = MaxSpeed;
    }
}
