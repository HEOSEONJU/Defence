using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Base_Manager : MonoBehaviour
{

    [SerializeField]
    List<Transform> Ground_Position;

    int Current_INDEX = 0;

    [SerializeField]
    List<GameObject> ObjectList;

    [SerializeField]
    Transform Pooling_Parent;
    int C = 0;
    

    List<GameObject> InstObject;

    private void Start()
    {
        InstObject = new List<GameObject>();
    }
    public void Spwan_Object(int N)
    {
        if (Current_INDEX == Ground_Position.Count) { Current_INDEX = 0; }
        int INDEX = ObjectList[N].GetComponent<Unit_Status>().ID;

        foreach (GameObject T in InstObject) 
        {
            if(T.TryGetComponent<Unit_Status>(out Unit_Status status)) 
            {
                if(status.ID == INDEX && !status.gameObject.activeSelf)
                {
                    T.gameObject.SetActive(true);
                    T.transform.position = Ground_Position[Current_INDEX].position;
                    Unit_Manager UM = T.GetComponent<Unit_Manager>();
                    UM.Init(Current_INDEX++);
                    UM.Reset_Animation();
                    
                    return;
                    
                    
                    
                    
                    
                }
            }
        }


        var e= Instantiate(ObjectList[N], Ground_Position[Current_INDEX].position, Quaternion.identity, Pooling_Parent);
        e.GetComponent<Unit_Manager>().Init(Current_INDEX++);
        InstObject.Add(e);
        e.name = "¾Æ±º" + C++;
    }
}
