using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{
    [SerializeField]
    List<Transform> Ground_Position;

    int Current_INDEX = 0;

    [SerializeField]
    List<GameObject> ObjectList;
    [SerializeField]
    List<float> Current_CoolTime;
    [SerializeField]
    List<float> Max_CoolTime;

    [SerializeField]
    Transform Pooling_Parent;
    int C = 0;

    [SerializeField]
    List<GameObject> InstObject;

    bool Live;
    private void Start()
    {
        Live= true;
        InstObject = new List<GameObject>();
        for(int i=0;i<Max_CoolTime.Count;i++)
        {
            Current_CoolTime.Add(0);
        }

    }
    private void Update()
    {
        if(!Live)
        {
            return;
        }
        for(int i=0; i< Max_CoolTime.Count;i++)
        {
            Current_CoolTime[i] += Time.deltaTime;
            if (Current_CoolTime[i]< Max_CoolTime[i])
            {
                continue;
            }
            Current_CoolTime[i] = 0.0f;
            
            if(Current_INDEX==Ground_Position.Count) { Current_INDEX = 0; }

            int INDEX = ObjectList[i].GetComponent<Unit_Status>().ID;
            
                foreach (GameObject T in InstObject)
                {
                
                    if (T.TryGetComponent<Unit_Status>(out Unit_Status status))
                    {
                        Debug.Log(T.name + "컴포넌트있는지확인됨");
                        if (status.ID == INDEX && !status.gameObject.activeSelf)
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


                var e = Instantiate(ObjectList[i], Ground_Position[Current_INDEX].position,Quaternion.Euler(new Vector3(0,-180,0)), Pooling_Parent);
                e.GetComponent<Unit_Manager>().Init(Current_INDEX++);
                InstObject.Add(e);
            e.name = "적군" + C++;
            

        }
    }
}
