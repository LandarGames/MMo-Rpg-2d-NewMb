using UnityEngine;
using System.Threading.Tasks;
using System;
using Unity.Mathematics;

public class NinjaStrikes : Power
{
    [SerializeField] private float _time;
    [SerializeField] private int _atak;
    [SerializeField] private float _skailDamage;
    [SerializeField] private GameObject _projectail;
    public override async void Skil(GameObject player, int skil, State state, GameObject target)
    {
        float _damage = state.Damage * _skailDamage ;
        PowerSkil = Convert.ToInt32(_damage) * _atak;
        float time = 0;
        float atakSpeed = 0;
        player.SetActive(false);
        GameObject ninja = Instantiate(_projectail, player.transform.position, player.GetComponent<Player>().Gun.transform.rotation);
        Vector2 pos1 = ninja.transform.position;
        Vector2 pos2 = target.transform.position;
        while (Vector2.Distance(pos1, pos2) >= 0.5f)
        {
            pos1 = ninja.transform.position;
            pos2 = target.transform.position;
            await Task.Delay(1);
            ninja.transform.position = Vector2.MoveTowards(ninja.transform.position, target.transform.position, 15 * Time.deltaTime);
        }
        Destroy(ninja);
        while (_time >= time && target == true)
        {
            time += Time.deltaTime;
            atakSpeed += Time.deltaTime;
            await Task.Delay(1);
            if (atakSpeed > (_time / _atak - ((_time / _atak) / _atak) * 0.5f) - 1 / _atak)
            {
                Effect(target);
                target.GetComponent<State>().TakeDamage(state.Damage * _skailDamage, 2);
                atakSpeed = 0;
            }
        }
        if (target == true)
        {
            player.transform.position = target.transform.position;
        }
        player.SetActive(true);
        player.GetComponent<Skil>().KD[skil] = Kd;
    }

    public override async void End(GameObject player)
    {
        
    }

    private async void Effect(GameObject target)
    {
        int helpx = UnityEngine.Random.Range(-1, 2);
        int helpy = UnityEngine.Random.Range(-1, 2);
        Debug.Log(helpx);
        Debug.Log(helpy);
        float rangeNinja = 3;
        if (helpx != 0 && helpy != 0)
        {
            Vector2 pos1 = target.transform.position + new Vector3(helpx * rangeNinja, helpy * rangeNinja, 0);
            Vector2 pos2 = target.transform.position + new Vector3(-(helpx * rangeNinja), -(helpy * rangeNinja), 0);
            GameObject ninja = Instantiate(_projectail, pos1, transform.rotation);
            while (Vector2.Distance(pos1, pos2) >= 0.5f)
            {
                pos1 = ninja.transform.position;
                pos2 = target.transform.position + new Vector3(-(helpx * rangeNinja), -(helpy * rangeNinja), 0);
                await Task.Delay(1);
                ninja.transform.position = Vector2.MoveTowards(ninja.transform.position, pos2, 40 * Time.deltaTime);
            }
            Destroy(ninja);
        }
        else
        {
            Effect(target);
        }
    }
}
