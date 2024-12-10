using System.Collections.Generic;
using UnityEngine;

public class MobeSpeed : Mobe
{
    private GameObject _target;
    private float _time;

    [SerializeField] private float _rangeSee;
    void Update()
    {
        if (GetComponent<NegativeEffect>().Stan < 0)
        {
            if (Range(_rangeSee).Count > 0)
            {
                Run(SeeUnit(Range(_rangeSee)));
            }
            if (Range(_range).Count > 0)
            {
                Atak(SeeUnit(Range(_range)));
            }
            
        }
        if (GetComponent<State>().Hp <= 0)
        {
            Dead();
        }
    }
    private void Atak(GameObject target)
    {
        _time += Time.deltaTime;
        if (GetComponent<State>().AtakSpeed <= _time) 
        {
           _spawnProjectail.transform.position = target.transform.position;
           _spawnProjectail.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 180);
           _projectile.GetComponent<ProjectileDamage>().Parent = gameObject;
           _projectile.GetComponent<ProjectileDamage>().Damage = GetComponent<State>().Damage; _projectile.GetComponent<ProjectileDamage>().Damage = GetComponent<State>().Damage;
           Instantiate(_projectile, _spawnProjectail.transform.position, _spawnProjectail.transform.rotation);
           _time = 0;
        }
    }

    private void Run(GameObject target)
    {
        if (Vector2.Distance(transform.position, target.transform.position) >= _range / 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, GetComponent<State>().RealSpeed * Time.deltaTime);
        }     
    }
}
