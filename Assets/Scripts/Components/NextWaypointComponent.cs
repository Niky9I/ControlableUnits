using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWaypointComponent : MonoBehaviour
{
	public Transform[] NextWaypointsPlayer1;
	public Transform[] NextWaypointsPlayer2;
    private bool PathIsChoosen;
    private int TempPath;
    
    private void Start()
    {
        PathComponent.IsActive += PathNumberIsChanged;

    }
    private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<OwnerComponent>(out var ownerComponent))
		{
			var otherWaypoint = other.GetComponent<WayPointComponent>();
			if (ownerComponent.Player == PlayerSide.Player1)
			{
				otherWaypoint.EndPoint = GetNextPoint(NextWaypointsPlayer1);
			}
			else
			{
				otherWaypoint.EndPoint = GetNextPoint(NextWaypointsPlayer2);
			}

		}
	}

	private Transform GetNextPoint(Transform[] pointsArray)
	{
		if (pointsArray != null)
		{
            if (PathIsChoosen && (pointsArray.Length>1) && (pointsArray==NextWaypointsPlayer1))
            {
                
                return pointsArray[TempPath];
            }
            return pointsArray[Random.Range(0, pointsArray.Length)];
		}
		else
			return null;
	}

    // Обработчик события выбора тропы для юнитов
    public void PathNumberIsChanged(object sender, PathEventArgs e)
    {
        Debug.Log(string.Format("Я знаю, что тропа изменилась на № {0}", e.PathNumber));
        TempPath = e.PathNumber; // номер тропы
        PathIsChoosen = true;
    }
}
