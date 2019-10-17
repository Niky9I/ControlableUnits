using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Casern : MonoBehaviour, ISelectable, IPointerClickHandler

{
    public int WarriorCost = 220;
    public string WarriorName = "Мечник";
    public int ArcherCost = 300;
    public string ArcherName = "Лучник";

    public delegate void CasernIsSelected(object sender, BuildingsEventArgs e);
    public event CasernIsSelected CasernIsSelectedEvent;
    public Button1 button1;
    public Button2 button2;
    GameObject Button1Mesh;
    GameObject Button2Mesh;

    void Awake()
    {
        Button1Mesh = GameObject.Find("Button1");
        Button2Mesh = GameObject.Find("Button2");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Button1Mesh.SetActive(true);
        Button2Mesh.SetActive(true);
        CasernIsSelectedEvent += button1.BuildingIsSelected; // убрать в Loop
        CasernIsSelectedEvent += button2.BuildingIsSelected; // убрать в Loop
        Select();

    }

    public void Select()
    {
        var canvas = GameObject.FindGameObjectWithTag("BuildingMenu");
        var Button1 = GameObject.Find("Button1Text").GetComponent<Text>();
        var Button2 = GameObject.Find("Button2Text").GetComponent<Text>();
        Button1.text = WarriorName;
        Button2.text = ArcherName;

        var e = new BuildingsEventArgs { UnitCost1 = WarriorCost, UnitName1 = WarriorName, UnitCost2 = ArcherCost, UnitName2 = ArcherName };
        CasernIsSelectedEvent(this, e);
    }
}
