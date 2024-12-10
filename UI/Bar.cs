using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public GameObject _komponent;
    public Image _maxHp;
    public TextMeshProUGUI _textHp;
    public TextMeshProUGUI _textLvl;
    public int _hp;

    private void Update()
    {
       
        if (_komponent.GetComponent<State>())
        {
            _hp = (int)_komponent.GetComponent<State>().Hp;
            _maxHp.GetComponent<Image>().fillAmount = _komponent.GetComponent<State>().Hp / _komponent.GetComponent<State>().MaxHP;
            _textHp.text = _hp.ToString();
            _textLvl.text = _komponent.GetComponent<State>().Power.ToString();
        }
    }
}
