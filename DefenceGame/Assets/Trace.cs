using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform T;

    private void Update()
    {
        Vector2 Dir = new Vector2(T.position.x - transform.position.x, T.position.y - transform.position.y);
        transform.up = Dir.normalized;
//        transform.rotation= Quaternion.LookRotation(Dir);

    }

}
