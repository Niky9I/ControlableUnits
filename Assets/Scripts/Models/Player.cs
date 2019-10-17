using UnityEngine.UI;
[System.Serializable]
public class Player// : MonoBehaviour
{
	public string Name;
	public PlayerSide PlayerSide;
	public int Gold;
	public int GoldMax;
	public GameSide GameSide;
	public Text GoldIndicator; //Временно для простой индикации
}
