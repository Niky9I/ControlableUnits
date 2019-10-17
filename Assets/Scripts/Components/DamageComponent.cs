using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
	public PlayerSide Damager;
	public int Damage;
	public DamageTypes DamageType;

	private int _hp;

    // Update is called once per frame
    void Update()
    {
		if (gameObject.TryGetComponent<HPComponent>(out var hpComponent))
		{
			hpComponent.SubstractHP(Damage);
			Debug.Log($"{gameObject.name} gains {Damage} dmg HP: {hpComponent.CurrentHP}");
			if (hpComponent.CurrentHP <= 0)
			{
				var destroyComponent = gameObject.AddComponent<NeedDestroyComponent>();
				destroyComponent.Destroyer = Damager;
			}
		}
		Destroy(this);
    }
}
