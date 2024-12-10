using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel : Bar
{
    [SerializeField] private TextMeshProUGUI _damage;
    [SerializeField] private TextMeshProUGUI _magedamage;
    [SerializeField] private TextMeshProUGUI _shielt;
    [SerializeField] private TextMeshProUGUI _mageShielt;
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _mageHealth;
    [SerializeField] private TextMeshProUGUI _manaText;
    [SerializeField] private TextMeshProUGUI _agilText;
    [SerializeField] private Image _kd1;
    [SerializeField] private Image _kd2;
    [SerializeField] private Image _kd3;
    [SerializeField] private Image _mana;
    [SerializeField] private Image _agil;
    [SerializeField] private Image[] _items;

    private void Update()
    {
        if (_komponent.GetComponent<Player>())
        {
            for(int item = 0; item < _items.Length; item++)
            {
                if (_komponent.GetComponent<Player>().Item[item] == null)
                {
                    _items[item].GetComponent<Image>().color = new Color(255, 255, 255, 0);
                }
                else
                {
                    _items[item].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    _items[item].GetComponent<Image>().sprite = _komponent.GetComponent<Player>().Item[item].GetComponent<ItemPasiv>().Image;
                }
            }
        }
        if (_komponent.GetComponent<State>())
        {
            _manaText.text = ((int)_komponent.GetComponent<State>().Mana).ToString();
            _agilText.text = _komponent.GetComponent<State>().JerkReal.ToString();
            _hp = (int)_komponent.GetComponent<State>().Hp;
            _mana.GetComponent<Image>().fillAmount = _komponent.GetComponent<State>().Mana / _komponent.GetComponent<State>().ManaMax;
            _agil.GetComponent<Image>().fillAmount = _komponent.GetComponent<State>().JerkKdReal / _komponent.GetComponent<State>().JerkKd;
            _maxHp.GetComponent<Image>().fillAmount = _komponent.GetComponent<State>().Hp / _komponent.GetComponent<State>().MaxHP;
            _textHp.text = _hp.ToString();
            _textLvl.text = _komponent.GetComponent<State>().Power.ToString();
            _damage.text = ((int)_komponent.GetComponent<Player>().Gun.GetComponent<Gun>()._damage).ToString();
            _magedamage.text = ((int)_komponent.GetComponent<State>().DopMageDamage).ToString();
            _shielt.text = ((int)_komponent.GetComponent<State>().PhisArmor).ToString();
            _mageShielt.text = ((int)_komponent.GetComponent<State>().MageArmor).ToString();
            _health.text = ((int)_komponent.GetComponent<State>().PhisHealt).ToString();
            _mageHealth.text = ((int)_komponent.GetComponent<State>().MageHealt).ToString();
            _kd1.fillAmount = _komponent.GetComponent<Skil>().KD[0] / _komponent.GetComponent<Skil>().Skils[0].GetComponent<Power>().Kd;
            _kd2.fillAmount = _komponent.GetComponent<Skil>().KD[1] / _komponent.GetComponent<Skil>().Skils[1].GetComponent<Power>().Kd;
            _kd3.fillAmount = _komponent.GetComponent<Skil>().KD[2] / _komponent.GetComponent<Skil>().Skils[2].GetComponent<Power>().Kd;

        }
    }
}
