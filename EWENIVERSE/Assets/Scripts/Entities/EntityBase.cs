using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityBase : MonoBehaviour
{
    public string entityName;
    public float health = 100f;
    public Vector3 position;
    protected Rigidbody rb;

    protected virtual void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();    
    }

    // Move the entity to a new position
    public abstract void Move();
    

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