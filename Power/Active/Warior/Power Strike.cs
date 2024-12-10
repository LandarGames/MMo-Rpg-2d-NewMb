using UnityEngine;

public class PowerStrike : Power
{
    public bool Active = false;

    [SerializeField] private float _dopDamage;
    [SerializeField] private float _dopHealt;
    [SerializeField] private float _kd;
    [SerializeField] private float _atak;

    public override void Skil(GameObject player, int skil, State state, GameObject target)
    {
        if (player.GetComponent<State>())
        {
            if (Active == false)
            {
                player.GetComponent<State>().Damage += _dopDamage;
                player.GetComponent<State>().PhisHealt += _dopHealt;
                Active = true;
              
            }
        }   
    } 

    public override void End(GameObject player)
    {
        if (player.GetComponent<State>())
        {
            if (Active == true)
            {
                player.GetComponent<State>().Damage -= _dopDamage;
                player.GetComponent<State>().PhisHealt -= _dopHealt;
                Active = false;
            }
        }     
    }
}
