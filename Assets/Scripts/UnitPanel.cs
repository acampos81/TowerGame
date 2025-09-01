using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitPanel : MonoBehaviour
{
  public GoldManager goldManager;
  public TMP_Text meleeCostField;
  public TMP_Text rangedCostField;
  public Button meleeBuyButton;
  public Button rangedBuyButton;

  private void OnEnable()
  {
    CheckPlayerGold();
  }

  void Start()
  {
    SetGoldPrices();
  }

  private void SetGoldPrices()
  {
    meleeCostField.text = goldManager.goldData.meleeUnitCost.ToString();
    rangedCostField.text = goldManager.goldData.rangedUnitCost.ToString();
  }

  private void CheckPlayerGold()
  {
    var playerGold = goldManager.GetPlayerGold();
    meleeBuyButton.interactable = playerGold >= goldManager.goldData.meleeUnitCost;
    rangedBuyButton.interactable = playerGold >= goldManager.goldData.rangedUnitCost;
  }
}
