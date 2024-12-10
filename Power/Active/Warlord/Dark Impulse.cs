using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DarkImpulse : Power
{
    [SerializeField] private float _startDamageBaze;
    [SerializeField] private float _range;
    [SerializeField] private float _skailStartDamage;
    [SerializeField] private float _endDamageProcent;
    private GameObject _parent;

    public override async void Skil(GameObject player, int skil, State state, GameObject target)
    {
        _parent = player;
        float startDamage = _startDamageBaze + _skailStartDamage;
        float endDamage = _endDamageProcent * (target.GetComponent<State>().MaxHP / 100);
        AllDamage(target, _range, startDamage);
        float _time = 0;
        while (_time < 1)
        {      
            if (!target)
            {
                return;
            }
            _time += Time.deltaTime;
            await Task.Delay(1);
        }
        target.GetComponent<State>().TakeDamage(endDamage, 1);
    }

    public void AllDamage(GameObject targetPoint, float range, float damage)
    {
        Vector2 size = new Vector2(range,range);
        Collider2D[] targets = Physics2D.OverlapCapsuleAll(targetPoint.transform.position,size,CapsuleDirection2D.Horizontal,360f);

        foreach (Collider2D target in targets)
        {
            if (target.GetComponent<State>() && target.gameObject != _parent)
            {
                target.GetComponent<State>().TakeDamage(damage, 1);
            }
        }
    }

    public override void End(GameObject player)
    {

    }
}
