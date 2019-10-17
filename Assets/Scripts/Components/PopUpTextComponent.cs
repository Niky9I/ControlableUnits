using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTextComponent : MonoBehaviour
{
	public TextMesh Text;
	public float YOffset;

	public Color GoldColor;
	public Color HPUpColor;
	public Color HPDownColor;

	private void Start()
	{
		if (gameObject.TryGetComponent<ProduceComponent>(out var produce))
		{
			produce.AddGold += ShowAmmount;
		}
		if (gameObject.TryGetComponent<HPComponent>(out var hP))
		{
			hP.HealthChange += ShowAmmount;
		}
		if (gameObject.TryGetComponent<SpawnerComponent> (out var spawner))
		{
			spawner.SpendGold += ShowAmmount;
		}
	}

	private void OnDestroy()
	{
		if (gameObject.TryGetComponent<ProduceComponent>(out var produce))
		{
			produce.AddGold -= ShowAmmount;
		}
		if (gameObject.TryGetComponent<HPComponent>(out var hP))
		{
			hP.HealthChange -= ShowAmmount;
		}
		if (gameObject.TryGetComponent<SpawnerComponent>(out var spawner))
		{
			spawner.SpendGold -= ShowAmmount;
		}
	}

	public void ShowAmmount (PopUpTypes type, int ammount)
	{
		if (Text != null)
		{
			//var tempText = Instantiate(Text, gameObject.transform.position + Vector3.up * YOffset, gameObject.transform.rotation);
			var tempText = Instantiate(Text, gameObject.transform.position + Vector3.up * YOffset, Quaternion.identity, transform);
			switch (type)
			{
				case PopUpTypes.GoldUp:
					tempText.color = GoldColor;
					tempText.text = $"+ {ammount}";
					break;
				case PopUpTypes.GoldDown:
					tempText.color = GoldColor;
					tempText.text = $"- {ammount}";
					break;
				case PopUpTypes.HealthUp:
					tempText.color = HPUpColor;
					tempText.text = $"{ammount}";
					break;
				case PopUpTypes.HealthDown:
					tempText.color = HPDownColor;
					tempText.text = $"{ammount}";
					break;
				default:
					break;
			}
		}
		
	}
}
