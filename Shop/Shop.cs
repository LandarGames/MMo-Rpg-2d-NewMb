using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Player Buyer;
    [SerializeField] TextMeshProUGUI _money;

    private void Update()
    {
        _money.text = Buyer.Money.ToString();
    }
}
