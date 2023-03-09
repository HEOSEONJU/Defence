using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Status : MonoBehaviour
{
    public int ID;
    Unit_Manager _manager;

    public float HP;
    public float distance;
    public bool Live;

    public void Cal_Distance(Vector2 Target)
    {
        distance= (Target- (Vector2)transform.position).magnitude;
    }

    
    // Start is called before the first frame update
    public void Init(Unit_Manager manager)
    {
        
        _manager = manager;
        Live = true;
    }

    public void Damaged(float DA)
    {
        HP -= DA;
        Debug.Log(name + "ÀÜ¿©Ã¼·Â" + HP);
        

        if(HP <= 0 && Live==true) { 
            
            Live = false;
            _manager.Start_Die_Animation();
            

        }
    }
}
