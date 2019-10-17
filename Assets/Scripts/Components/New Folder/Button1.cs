using UnityEngine;
using UnityEngine.EventSystems;


public class Button1 : MonoBehaviour, IPointerDownHandler
{
    int TempUnitCost;
    string TempUnitName;


    public delegate void GoldWasted(object sender, ButtonTempEventArgs e);
    public event GoldWasted GoldWastedEvent;

    public void OnPointerDown(PointerEventData eventData)
    {

        var e = new ButtonTempEventArgs { TempCost = TempUnitCost, TempName = TempUnitName };
        GoldWastedEvent(this, e);
    }
    // Обработчик события смены функции кнопки при изменении выделенного здания
    //public void ButtonIsPressed(object sender, ButtonTempEventArgs e)
    //{
    //    var CostForSpawn = e.TempCost; //стоимость юнита
    //    var NameForSpawn = e.TempName; //тип юнита
    //    Debug.Log(string.Format("Заказан {0} стоимостью {1}", NameForSpawn, CostForSpawn));
    //}

    public void BuildingIsSelected(object sender, BuildingsEventArgs e)
    {
        Debug.Log("Данные о здании переданы!");
        TempUnitCost = e.UnitCost1; //стоимость юнита
        TempUnitName = e.UnitName1; //тип юнита
    }


}
