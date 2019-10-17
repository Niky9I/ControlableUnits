using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(OwnerComponent))]
public class SpawnerComponent : MonoBehaviour
{
	public event Action<PopUpTypes, int> SpendGold;

	public GameObject Swordman;
    public GameObject Archer;
    public GameObject Prefab;
    /*[HideInInspector] */
    public float SpawnTime;
	public float SpawnDelay;
	public KeyCode spawnKey;
	public bool Autospawn;

	private float _deltaTime;
	private bool _spawnInProgress;
	private int _counter = 0;
	private PlayerSide _playerSide;
	private GameLoopManager _gameManager;
    
    Button1 button1=new Button1();
    Button2 button2=new Button2();
   
   

   
    // Start is called before the first frame update
    void Start()
	{
       
        button1.GoldWastedEvent += Button1IsPressed;
        button2.GoldWastedEvent += Button2IsPressed;
        SpawnTime = 0;
		_spawnInProgress = false;
		_playerSide = gameObject.GetComponent<OwnerComponent>().Player;
		_gameManager = FindObjectOfType<GameLoopManager>();
	}
	void Update()
	{
		if (Input.GetKeyDown(spawnKey) || Autospawn)
		{
			 InitializeSpawn(); //
		}
		if (!_spawnInProgress)
			return;
		_deltaTime = Time.deltaTime;
		if (_spawnInProgress)
		{
			SpawnTime += _deltaTime;
			if (SpawnTime >= SpawnDelay)
			{
				ExecuteSpawn(); // Выключил автоспаунер
			}
		}
	}

	private void InitializeSpawn()
	{
		if (_spawnInProgress)
			return;
		else
		{
			var spawnCost = Prefab.GetComponent<CostComponent>().Gold;
			if (_gameManager.GetGold(_playerSide, spawnCost))
			{
				SpendGold?.Invoke(PopUpTypes.GoldDown, spawnCost);
				//SpawnTime = 0;
				_spawnInProgress = true;
			}
		}
	}

	private void ExecuteSpawn()
	{
		GameObject tempObject = Instantiate(Prefab, transform.position, transform.rotation);
		if (gameObject.TryGetComponent<OwnerComponent>(out var ownerComponent))
		{
			var tempOwner = tempObject.GetComponent<OwnerComponent>();
			tempOwner.Player = ownerComponent.Player;
		}
		if (gameObject.TryGetComponent<WayPointComponent>(out var wayPointComponent))
		{
			var tempWayPoint = tempObject.GetComponent<WayPointComponent>();
			tempWayPoint.EndPoint = wayPointComponent.EndPoint;
		}
		tempObject.name += $" {_counter}";
		_counter++;
		_spawnInProgress = false;
		SpawnTime = 0;
	}

    public void Button1IsPressed(object sender, ButtonTempEventArgs e)
    {
        var CostForSpawn = e.TempCost; //стоимость юнита
        var NameForSpawn = e.TempName; //тип юнита
        Debug.Log(string.Format("Заказан {0} стоимостью {1}", NameForSpawn, CostForSpawn));
        //Prefab = Swordman;
        //InitializeSpawn();
        //ExecuteSpawn();
    }
    public void Button2IsPressed(object sender, ButtonTempEventArgs e)
    {
        var CostForSpawn = e.TempCost; //стоимость юнита
        var NameForSpawn = e.TempName; //тип юнита
        Debug.Log(string.Format("Заказан {0} стоимостью {1}", NameForSpawn, CostForSpawn));
        //Prefab = Archer;
        //InitializeSpawn();
        //ExecuteSpawn();
    }
}
