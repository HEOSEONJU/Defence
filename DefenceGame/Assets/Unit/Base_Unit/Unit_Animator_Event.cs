using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Animator_Event : MonoBehaviour
{
    Unit_Manager _manager;
    public Animator _Animator;

    [SerializeField]
    Vector3 Value;
    // Start is called before the first frame update
    public void Init(Unit_Manager manager)
    {
        _manager = manager;
    }


    public void Disable_Object()
    {
        _manager.End_Die_Animation();
    }

    public void Damage_Function()
    {
        _manager.Damage();
    }
    public void Move_Shoot()
    {

        transform.localPosition = Value;
    }
    public void ResetPosition()
    {
        transform.localPosition= Vector3.zero;
    }
}
