using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Move : MonoBehaviour
{
    
    Unit_Manager _manager;
    
    public void Init(Unit_Manager manager)
    {
        _manager = manager;
    }



    public void Move_Front(Unit_Status T, Unit_Animator_Event Event_Animator)
    {
        if(T!=null || Event_Animator._Animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) 
        {
            Event_Animator._Animator.SetBool("RUN", false);
            return;
        }
        Event_Animator._Animator.SetBool("RUN",true);
        switch(_manager.Camp)
        {
            case true:
                transform.position += Vector3.right * Time.deltaTime;
                break;
                default:
                transform.position -= Vector3.right * Time.deltaTime;
                break;
        }
        



    }
}
