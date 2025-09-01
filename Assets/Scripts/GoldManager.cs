using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
  public GoldData goldData;
  public TMP_Text goldField;

  private int _playerGold;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    UpdateGold(goldData.startingGold);
  }

  public void UnitPurchased(int unitType)
  {
    switch(unitType)
    {
      case 0:
        UpdateGold(-goldData.meleeUnitCost);
        break;
      case 1:
        UpdateGold(-goldData.rangedUnitCost);
        break;
    }
  }

  public void EnemyReward(int enemyType)
  {
    switch(enemyType)
    {
      case 0:
        UpdateGold(goldData.enemy1Reward);
        break;
      case 1:
        UpdateGold(goldData.enemy2Reward);
        break;
    }
  }

  public void UpdateGold(int amount)
  {
    _playerGold += amount;
    goldField.text = _playerGold.ToString();
  }

  public int GetPlayerGold()
  {
    return _playerGold;
  }
}
