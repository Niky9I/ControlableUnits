using UnityEngine;
using UnityEngine.EventSystems;

public class PathComponent : MonoBehaviour, IPointerClickHandler
{
    public int ThisPathNumber;
    public delegate void PathStateHandler(object sender, PathEventArgs e); //Объявляем делегат
    public static event PathStateHandler IsActive; //Событие, возникающее при выборе этой тропы
    GameObject[] pathes;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Активна тропа № {ThisPathNumber}");
        var e = new PathEventArgs { PathNumber = ThisPathNumber };
        IsActive(this, e);

        pathes = GameObject.FindGameObjectsWithTag("Path");
        foreach (var path in pathes)
        {
            path.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        
        gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public static void PathNumberIsChanged(object sender, PathEventArgs e)
    {
        Debug.Log(string.Format("Я знаю, что тропа изменилась на № {0}", e.PathNumber));
        var path = e.PathNumber; // номер тропы
    }

}
