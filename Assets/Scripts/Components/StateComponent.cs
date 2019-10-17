using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateComponent : MonoBehaviour
{
	public UnitStates state;

	private NavMeshAgent _agent;
	private SpeedComponent _speed;
	private OwnerComponent _owner;

	private void Start()
	{
		_agent = gameObject.GetComponent<NavMeshAgent>();
		_speed = gameObject.GetComponent<SpeedComponent>();
		_owner = gameObject.GetComponent<OwnerComponent>();
	}
	void Update()
    {
		var target = gameObject.GetComponent<TargetComponent>();
		var waypoint = gameObject.GetComponent<WayPointComponent>();
		var capture = gameObject.GetComponent<CaptureComponent>();
		switch (state)
		{
			case UnitStates.Idle:
				if (waypoint != null && waypoint.EndPoint != null)
				{
					_agent.destination = waypoint.EndPoint.position;
					_agent.speed = _speed.CurrentSpeed;
					state = UnitStates.Moving;
				}
				break;
			case UnitStates.Moving:
				if (target != null)
				{
					_agent.destination = target.gameObject.transform.position;
					_agent.speed = 0;
					state = UnitStates.Attacking;
				}
				if (waypoint != null && waypoint.EndPoint != null)
				{
					_agent.destination = waypoint.EndPoint.position;
				}
				if (capture != null && capture.CapturingBuilding != null && capture.CapturingBuilding.GetComponent<OwnerComponent>().Player != _owner.Player)
				{
					_agent.destination = capture.gameObject.transform.position;
					_agent.speed = 0;
					state = UnitStates.Capturing;
				}
				break;
			case UnitStates.Attacking:
				if (target == null)
				{
					state = UnitStates.Idle;
				}
				break;
			case UnitStates.Capturing:
				if (capture.CapturingBuilding == null || capture.CapturingBuilding.GetComponent<OwnerComponent>().Player == _owner.Player)
				{
					state = UnitStates.Idle;
				}
				break;
			default:
				break;
		}
    }
}
