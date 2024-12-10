using System.Collections.Generic;
using UnityEngine;


public class Mobe : OpenKeys
{
    public GameObject DeadModel;
    public GameObject _projectile;
    public Transform _spawnProjectail;
    public float _range;

    private GameObject _target;
    private float _time;

    void Update()
    {
        Range(_range);
        if (GetComponent<NegativeEffect>().Stan < 0)
        {
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

    public GameObject SeeUnit(List<GameObject> targets)
    {
        float distance = Mathf.Infinity;
        GameObject target = null;
        Vector3 position = transform.position;
        foreach (GameObject go in targets)
        {
            Vector2 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                distance = curDistance;
                target = go;
            }
        }
        return target;
    }

    public List<GameObject> Range(float range)
    {
       Vector2 size = new Vector2(range, range);
       Collider2D[] see = Physics2D.OverlapCapsuleAll(transform.position,size,CapsuleDirection2D.Horizontal, 360f);

        List<GameObject> targets = new();

        foreach(Collider2D target in see)
        {
            if (target.GetComponent<Player>())
            {
                targets.Add(target.gameObject);
            }
        }
        return targets;
    }
    private void Atak(GameObject target)
    {
        _time += Time.deltaTime;
        if (GetComponent<State>().AtakSpeed <= _time)
        {
            _spawnProjectail.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 180);
            _projectile.GetComponent<ProjectileDamage>().Parent = gameObject;
            _projectile.GetComponent<ProjectileDamage>().Damage = GetComponent<State>().Damage;
            Instantiate(_projectile, _spawnProjectail.transform.position, _spawnProjectail.transform.rotation);
            _time = 0;
        }     
    }   

    public void Dead()
    {
        Open();
        Destroy(gameObject);
        Instantiate(DeadModel, _spawnProjectail.transform.position, Quaternion.identity);
    }
}
