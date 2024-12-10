using Unity.VisualScripting;
using UnityEngine;

public class BloodWarior : Power
{
    [SerializeField] private float _dop;
    [SerializeField] private float _dopDamage;
    [SerializeField] private float _maxDop;

    [SerializeField] private float _help = 0;

    public override void Skil(GameObject player, int skil, State state, GameObject target)
    {
        if (player.GetComponent<State>())
        {
            if (_help < _maxDop)
            {
                _help += _dop * Time.deltaTime;
                player.GetComponent<State>().Damage += _dop * Time.deltaTime;
                player.GetComponent<State>().PhisHealt += _dop * Time.deltaTime;
            }
            player.GetComponent<State>().TakeDamage((_dop * (player.GetComponent<State>().MaxHP / 100)) * (_help * _dopDamage) * Time.deltaTime, 2);
        }
    }

    public override void End(GameObject player)
    {
        if (player.GetComponent<State>())
        {
            player.GetComponent<State>().Damage -= _help;
            player.GetComponent<State>().PhisHealt -= _help;
            _help = 0;
        }
    }
}
