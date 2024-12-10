using UnityEditor;
using UnityEngine;

public class Deafeningblow : Power
{
    [SerializeField] private float _dopDamage;
    [SerializeField] private float _atak;
    [SerializeField] private int _tipe;
    [SerializeField] private float _stan;
    [SerializeField] private float _kd;

    public override void Skil(GameObject player, int skil, State state, GameObject target)
    {
        player.GetComponent<State>().TakeDamage((state.Damage * _atak) + _dopDamage, _tipe);
        player.GetComponent<NegativeEffect>().Stans(_stan);
    }

    public override void End(GameObject player)
    {
        
    }
}
