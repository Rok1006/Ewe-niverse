using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ewe : Animal
{
    private float visionRange = 5f;

    private Vector3 moveDir;
    private Vector3 destination;

    public override void Move()
    {
        if (!isMoving)
        {
            if(foods.Count != 0)
            {
                moveDir = (foods[0].transform.position - transform.position).normalized;
                moveDir.y = 0;
                isMoving = true;
            }
        }
        else
        {
            Debug.Log("asdf");
            rb.AddForce(moveDir * Time.deltaTime * 10f , ForceMode.Impulse);
        }
    }
    protected override EntityBase SeekFood()
    {
        int layermask = 1 << 6;
        Collider[] entities = Physics.OverlapSphere(transform.position, visionRange, layermask);
        Debug.Log(entities[0].gameObject.name);
        foods = Environment.instance.FindPotentialFoodSource(this,  entities);
        Debug.Log(foods[0].GetComponent<EntityBase>().transform);
        return null;    
        
        
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SeekFood();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
