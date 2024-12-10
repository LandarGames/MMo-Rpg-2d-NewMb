using System.Threading.Tasks;
using UnityEngine;

public class PortalToHell : Power
{
    [SerializeField] private float _timeUp;
    private float _time;

    [Header("Base")]
    [SerializeField] private float _damage;
    [SerializeField] private float _long;
    [SerializeField] private float _intervalDamage;
    [SerializeField] private float _SlowDownProcent;

    [Header("Up")]
    [SerializeField] private float _damageUp;
    [SerializeField] private float _longStan;
    [SerializeField] private float _intervalDamageUp;


    public override async void Skil(GameObject player, int skil, State state, GameObject target)
    {
        if (_time > 0)
        {
            Up(state, target);
        }
        else
        {
            _time = _timeUp;
            float Damage = _damage / (_long / _intervalDamage);
            float LowSpeed = (target.GetComponent<State>().Speed / 100) * _SlowDownProcent;
            target.GetComponent<NegativeEffect>().SlowDown(LowSpeed, _long);
            target.GetComponent<NegativeEffect>().Burning(_intervalDamage, _long, Damage, 1);
        }
        while (_time > 0)
        {
            _time -= Time.deltaTime;
            await Task.Delay(1);
        }
    }

    private void Up(State state, GameObject target)
    {
        float Damage = _damageUp / (_longStan / _intervalDamageUp);
        state.GetComponent<State>().JerkReal -= 1;
        target.GetComponent<NegativeEffect>().Stans(_longStan);
        target.GetComponent<NegativeEffect>().Burning(_intervalDamageUp, _longStan, Damage, 1);
    }

    public override void End(GameObject player)
    {

    }
}
