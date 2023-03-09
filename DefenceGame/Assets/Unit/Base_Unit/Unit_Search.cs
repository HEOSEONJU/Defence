using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using System.Linq;

public class Unit_Search : MonoBehaviour
{
    Unit_Manager _manager;
    [SerializeField]
    float Range=3;
    float Height = 4;
    [SerializeField]
    public Unit_Status Target;
    // Start is called before the first frame update
    public void Init(Unit_Manager manager)
    {
        _manager = manager;
        Target = null;
    }



    public void Search_Target()
    {
        RaycastHit2D[] hits;
        switch (_manager.Camp)
        {

            case true:
                hits = Physics2D.BoxCastAll((Vector2)transform.position, Vector2.one * Height, 0, Vector2.right, Range);
                Array.Sort(hits ,(RaycastHit2D x, RaycastHit2D y) => x.distance.CompareTo(y.distance));
                foreach(RaycastHit2D hit in hits)
                {
                    

                    if (hit.transform.TryGetComponent<Unit_Status>(out Unit_Status T) && hit.transform.CompareTag("Enemy"))
                    {
                        Target = T;
                        return;
                    }
                }
                break;
            default:
                hits = Physics2D.BoxCastAll((Vector2)transform.position, Vector2.one * Height, 0, Vector2.left, Range);
                Array.Sort(hits, (RaycastHit2D x, RaycastHit2D y) => x.distance.CompareTo(y.distance));
                foreach (RaycastHit2D hit in hits)
                {
                    if (hit.transform.TryGetComponent<Unit_Status>(out Unit_Status T) && hit.transform.CompareTag("Player"))
                    {
                        Target = T;
                        return;
                    }
                }
                break;
        }
        Target = null;
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (_manager.Camp)
        {
            case true:
                if (!collision.CompareTag("Enemy"))
                {
                    return;
                }

                if (collision.TryGetComponent<Unit_Status>(out Unit_Status D1))
                {
                    Target.Add(D1);
                    return;
                }
                break;
            default:
                Debug.Log(name+"/"+collision.tag);
                if (!collision.CompareTag("Player"))
                {
                    
                    return;
                }

                if (collision.TryGetComponent<Unit_Status>(out Unit_Status D2))
                {
                    Target.Add(D2);
                    return;
                }
                break;
                

        }



        

            

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        switch (_manager.Camp)
        {
            case true:
                if (!collision.CompareTag("Enemy"))
                {
                    return;
                }

                if (collision.TryGetComponent<Unit_Status>(out Unit_Status D1))
                {
                    Target.Remove(Target.Find(x => x.GetInstanceID() == D1.GetInstanceID()));
                    return;
                }
                break;
            default:
                if (!collision.CompareTag("Player"))
                {
                    return;
                }

                if (collision.TryGetComponent<Unit_Status>(out Unit_Status D2))
                {
                    Target.Remove(Target.Find(x => x.GetInstanceID() == D2.GetInstanceID()));
                    return;
                }
                break;


        }

        
    }
    */

}
