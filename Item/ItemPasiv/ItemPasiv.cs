using UnityEngine;

public class ItemPasiv : MonoBehaviour
{
    public Sprite Image;
    public Color ColorFon;

    [Header("Hp")]
    public float _hp;

    [Header("Mage")]
    public float _mana;
    public float _mageDamage;
    public float _kdHeist;

    [Header("Atak")]
    public float _atakSpeed;
    public float _damage;

    [Header("Speed")]
    public int _jerkMax;
    public float _jerkKd;
    public float _jerkSpeed;
    public float _timeJerk;
    public float _speed;

    [Header("Armor")]
    public float _mageArmor;
    public float _phisArmor;

    [Header("Health")]
    public float _bazeRegen;
    public float _phisHealt;
    public float _mageHealt;

    public int Gold;
    private bool _act = false;
   

    public void Active(GameObject State)
    {
        if (_act == true)
        {
            return;
        }

        if (State.GetComponent<State>())
        {
            State.GetComponent<State>().ManaMax += _mana;
            State.GetComponent<State>().KdHeist += _kdHeist;
            State.GetComponent<State>().DopMageDamage += _mageDamage;
            State.GetComponent<State>().Damage += _damage;
            State.GetComponent<State>().AtakSpeed += _atakSpeed;
            State.GetComponent<State>().BazeRegen += _bazeRegen;
            State.GetComponent<State>().PhisHealt += _phisHealt;
            State.GetComponent<State>().MageHealt += _mageHealt;
            State.GetComponent<State>().PhisArmor += _phisArmor;
            State.GetComponent<State>().MageArmor += _mageArmor;
            State.GetComponent<State>().MaxHP += _hp;
            _act = true;
        }
    }

}
