using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private ItemPasiv item;
    [SerializeField] private Image UIitem;
    [SerializeField] private TextMeshProUGUI much;

    private void Awake()
    {
        UIitem.sprite = item.Image;
        much.text = item.Gold.ToString();
        GetComponent<Image>().color = item.ColorFon;
    }

    public void Bui()
    {
        if (_shop.Buyer.Money >= item.Gold)
        {
            for (int itemNum = 0; itemNum < _shop.Buyer.Item.Length; itemNum++)
            {
                if (_shop.Buyer.Item[itemNum] == null)
                {
                    _shop.Buyer.Item[itemNum] = item.gameObject;
                    _shop.Buyer.Items();
                    _shop.Buyer.Money -= item.Gold;
                    break;
                }
            }
        }
   
    }
}
