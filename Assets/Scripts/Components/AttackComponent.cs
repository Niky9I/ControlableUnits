using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
	public DamageTypes DamageType;
	public int MinDamage;
	public int MaxDamage;
	public float AttackDelay;
	[HideInInspector] public float AttackTime;
	//public int tickCount;
	//public float tickDelay;


	private PlayerSide _playerSide;

	void Update()
	{
		if (gameObject.TryGetComponent<TargetComponent>(out var targetComponent))
		{
			float deltaTime = Time.deltaTime;
			AttackTime += deltaTime;
			if (AttackTime >= AttackDelay)
			{
				if (targetComponent.TargetObject != null)
				{
					var damageComponent = targetComponent.TargetObject.AddComponent<DamageComponent>();
					damageComponent.DamageType = DamageType;
					damageComponent.Damage = Random.Range(MinDamage, MaxDamage);
					if (gameObject.TryGetComponent<OwnerComponent>(out var ownerComponent))
					{
						damageComponent.Damager = ownerComponent.Player;
					}
					else
					{
						damageComponent.Damager = PlayerSide.None;
					};
				}
				AttackTime = 0;
			};
		}
		else
		{
			AttackTime = 0;
		}
	}
}
