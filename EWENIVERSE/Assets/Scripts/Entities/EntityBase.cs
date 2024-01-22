using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityBase : MonoBehaviour
{
    protected string entityName;
    protected float health = 100f;
    protected Transform position;
    protected Rigidbody rb;

    
    public LayerMask groundLayer;

    protected virtual void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();    
    }

    public virtual void Init()
    {
        
    }
    // Move the entity to a new position

    protected abstract void GetEntityInfo();
    

    

    // Inflict damage to the entity
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            OnDeath();
        }
    }

    // This method will be called when the entity dies
    protected virtual void OnDeath()
    {
        Debug.Log($"{entityName} has died.");
        // You can add more logic here, like destroying the GameObject or triggering animations.
    }
}