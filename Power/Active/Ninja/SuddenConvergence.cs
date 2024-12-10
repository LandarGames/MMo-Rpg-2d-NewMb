using System;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class SuddenConvergence : Power
{
    [SerializeField] private float _speed;
    [SerializeField] private float _Distance;
    [SerializeField] private float _damage;
    [SerializeField] private GameObject _projectail;
    [SerializeField] private float _skail;
    private float _atak;

    private GameObject _target;
    public override async void Skil(GameObject player, int skil, State state, GameObject target)
    {
        player.GetComponent<Skil>().KD[skil] = Kd;
        _target = target;
        GameObject kruk = Instantiate(_projectail, player.transform.position, player.GetComponent<Player>().Gun.transform.rotation);
        Vector2 pos1 = kruk.transform.position;
        Vector2 pos2 = _target.transform.position;
        while (Vector2.Distance(pos1,pos2) >= _Distance)
        {
            pos1 = kruk.transform.position;
            pos2 = _target.transform.position;
            await Task.Delay(1);
            kruk.transform.position = Vector2.MoveTowards(kruk.transform.position, target.transform.position,_speed * Time.deltaTime);
        }
        target.GetComponent<State>().TakeDamage(_damage + state.Damage * _skail, 0);
        Destroy(kruk);
        End(player);
    }

    public override async void End(GameObject player)
    {
        _atak = player.GetComponent<State>().Damage;
        Vector2 pos1 = player.transform.position;
        Vector2 pos2 = _target.transform.position;
        while (Vector2.Distance(pos1, pos2) >= _Distance)
        {
            pos1 = player.transform.position;
            pos2 = _target.transform.position;
            await Task.Delay(1);
            player.transform.position = Vector2.MoveTowards(player.transform.position, _target.transform.position, _speed * Time.deltaTime);
            player.GetComponent<NegativeEffect>().AnimStan(1);
        }
        player.GetComponent<NegativeEffect>().AnimStan(0);
        _target.GetComponent<State>().TakeDamage(_atak, 0);
        PowerSkil = Convert.ToInt32(_damage) + Convert.ToInt32(_atak) + Convert.ToInt32(_Distance * _speed);
    }
}
