using UnityEngine;

[CreateAssetMenu(fileName = "GoldData", menuName = "Scriptable Objects/GoldData")]
public class GoldData : ScriptableObject
{
  public int startingGold;
  public int meleeUnitCost;
  public int rangedUnitCost;
  public int enemy1Reward;
  public int enemy2Reward;
}
