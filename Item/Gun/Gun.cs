using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.GraphicsBuffer;

public class Gun : MonoBehaviour
{
    public float _damage;

    [SerializeField] private float _atakSpeed;
    [SerializeField] private float _help;
    [SerializeField] private float _damageKombo;

    [SerializeField] private int _kombo;
    [SerializeField] private int _agilMuch;

    [SerializeField] private Transform _transformAtak;

    [SerializeField] private GameObject _atak;
    [SerializeField] private GameObject _projectileKombo;
    [SerializeField] private GameObject _effect;

    private float time;

    public float Range;


    private void Update()
    {
        time += Time.deltaTime;
    }
    public void Atak(State state, GameObject parent)
    {
        if (time > _atakSpeed && time >= 0.2f)
        {
            _atak.GetComponent<ProjectileDamage>().Parent = parent;
            _atak.GetComponent<ProjectileDamage>().Damage = _damage;
            _atak.GetComponent<ProjectileDamage>().Health = _damage + (state.PhisHealt / 100);
            Instantiate(_atak, _transformAtak.position ,transform.rotation);
            time = 0;
        }
        if (_kombo > 0 && (time > 0.05f && time <= 0.2f) &&  parent.GetComponent<State>().JerkReal >= _agilMuch)
        {
            for (int i = 0; i < _kombo; i++)
            {
                _projectileKombo.GetComponent<ProjectileDamage>().Parent = parent;
                _projectileKombo.GetComponent<ProjectileDamage>().Damage = _damageKombo;
                _effect?.GetComponent<Effect>().Efect(parent);
                parent.GetComponent<State>().TrataAgil(_agilMuch);
                Instantiate(_projectileKombo, _transformAtak.position, transform.rotation);
            }      
        }
    }

    public void Aim(GameObject target)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg - _help);
    }


}
