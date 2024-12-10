using System;
using Unity.VisualScripting;
using UnityEngine;

public class Fastshurikens : Power
{
    [SerializeField] private int _snarad;
    [SerializeField] private GameObject _shuriken;
    [SerializeField] private float _damage;
    [SerializeField] private float _dopDamage;
    [SerializeField] private float _helpRotation;
    [SerializeField] private float _skail;

    private Vector3 _help;
    public override void Skil(GameObject player, int skil, State state, GameObject target)
    {
        _dopDamage = state.Damage * _skail;
        PowerSkil = Convert.ToInt32((_damage + _dopDamage) * _snarad);
        _help = new Vector3(0, 0, 0);
        _shuriken.GetComponent<ProjectileDamage>().Parent = player;
        _shuriken.GetComponent<ProjectileDamage>().Damage = _damage + _dopDamage;
        for (int i = 0; i < _snarad; i++)
        {
            Instantiate(_shuriken, player.transform.position + _help,player.GetComponent<Player>().Gun.transform.rotation);
            _help.y += _helpRotation;
            _help.x += _helpRotation;
        }
        player.GetComponent<Skil>().KD[skil] = Kd;
    }

    public override void End(GameObject player)
    {

    }
}
