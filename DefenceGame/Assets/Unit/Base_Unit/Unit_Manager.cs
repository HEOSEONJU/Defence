using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using static UnityEngine.GraphicsBuffer;

public class Unit_Manager : MonoBehaviour
{
    [SerializeField]
    public bool Camp;
    [SerializeField]
    Unit_Attack _Attack;
    [SerializeField]
    Unit_Move _Move;
    [SerializeField]
    Unit_Search _Search;
    [SerializeField]
    Unit_Status _Status;
    [SerializeField]
    Unit_Animator_Event _Event;
    [SerializeField]
    SpriteRenderer _SpriteRenderer;
    Collider2D _Collider;
    
    void Start()
    {
        _Collider=GetComponent<Collider2D>();
        _Attack.Init(this);
        _Move.Init(this);
        _Search.Init(this);
        _Status.Init(this);
         _Event.Init(this);

    }
    public void Init(int Order)
    {
        _SpriteRenderer.sortingOrder = Order;
        _Status.Live = true;
        _Status.HP = 10;
        
        //체력최대치로

    }
    
    // Update is called once per frame
    void Update()
    {
        if (!_Status.Live) return;
        _Move.Move_Front(_Search.Target, _Event);
        
    }
    private void FixedUpdate()
    {
        if (!_Status.Live) return;
        _Search.Search_Target();
        _Attack.Attack(_Search.Target, _Event);

    }
    private void LateUpdate()
    {
        
        
        if (!_Status.Live) return;

    }

    
    public void Damage()
    {
        if(_Search.Target!=null)
        _Search.Target.Damaged(_Attack.AP);
    }
    public void Start_Die_Animation()
    {
        _Event._Animator.SetTrigger("Die");
        _Collider.enabled = false;
    }
    public void Reset_Animation()
    {
        _Event._Animator.SetTrigger("Reset");
        _Collider.enabled= true;
    }
    public void End_Die_Animation()
    {
        
        gameObject.SetActive(false);
    }
}
