using System.Threading.Tasks;
using UnityEngine;

public class DamnationOfHell : Power
{
    [SerializeField] private float _damageProcent;
    [SerializeField] private float _timeEnd;

    private float _startHp;
    private float _endHp;
    private float _time;

    public override async void Skil(GameObject player, int skil, State state, GameObject target)
    {
        _time = 0;
        _startHp = target.GetComponent<State>().Hp;
        while (_time < _timeEnd)
        {
            _time += Time.deltaTime;
            await Task.Delay(1);
        }
        _endHp = target.GetComponent<State>().Hp;
        float damage = (_startHp - _endHp) * _damageProcent;
        target.GetComponent<State>().TakeDamage(damage,1);
    }

    public override void End(GameObject player)
    {

    }
}
