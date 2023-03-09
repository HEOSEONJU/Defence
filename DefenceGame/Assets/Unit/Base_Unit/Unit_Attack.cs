using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Attack : MonoBehaviour
{
    Unit_Manager _manager;

    [SerializeField]
    public float AP;

    float Current_Delay = 0;
    [SerializeField]
    float Max_Delay;

    // Start is called before the first frame update
    public void Init(Unit_Manager manager)
    {
        _manager = manager;
    }

    public void Attack(Unit_Status T, Unit_Animator_Event Event_Animator)
    {
        Current_Delay += Time.deltaTime;
        if (T == null || Current_Delay < Max_Delay)
        {

            return;
        }

        if (T.Live)
        {
            Current_Delay = 0;
            Debug.Log(transform.name + "가" + T.name + "을공격중");
            Event_Animator._Animator.SetTrigger("Attack");
            

            return;
        }








    }



    


}


