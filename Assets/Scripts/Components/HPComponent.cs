using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HPComponent : MonoBehaviour
{
	public event Action<PopUpTypes, int> HealthChange;

	public int CurrentHP;
	public int MaxHP;
    void Start()
    {
		CurrentHP = MaxHP;
    }

	public void AddHP (int ammount)
	{
		CurrentHP += ammount;
		CorrectHP();
		HealthChange?.Invoke(PopUpTypes.HealthUp, ammount);
	}
	public void SubstractHP(int ammount)
	{
		CurrentHP -= ammount;
		CorrectHP();
		HealthChange?.Invoke(PopUpTypes.HealthDown, ammount);
	}
	private void CorrectHP()
	{
		if (CurrentHP > MaxHP)
			CurrentHP = MaxHP;
		if (CurrentHP < 0)
			CurrentHP = 0;
	}
}
