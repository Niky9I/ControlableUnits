using UnityEngine;

public class VisionComponent : MonoBehaviour
{
	public float AttackRange;

	private TargetComponent _target;
	private float _testDist;
	private PlayerSide _side;
	private void Awake()
	{
		_side = gameObject.GetComponent<OwnerComponent>().Player;
	}
	void Update()
    {
		_target = GetComponent<TargetComponent>();
		
		if (_target == null)
		{
			var targetsArray = FindObjectsOfType<HPComponent>();
			foreach (HPComponent target in targetsArray)
			{
				if (target.gameObject == gameObject) continue;
				if (target.gameObject.GetComponent<OwnerComponent>().Player == _side) continue;
				_testDist = Vector3.Distance(target.gameObject.transform.position, gameObject.transform.position);
				if (_testDist <= AttackRange)
				{
					var targetComponent = gameObject.AddComponent<TargetComponent>();
					targetComponent.TargetObject = target.gameObject;
				}
			}
		}
		else
		{
			Debug.DrawLine(_target.gameObject.transform.position, gameObject.transform.position,Color.magenta);
		}
    }
}
