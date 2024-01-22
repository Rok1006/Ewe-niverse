using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Environment : MonoBehaviour
{
    public static Dictionary<Type, List<Type>> consumptionDictionary = new Dictionary<Type, List<Type>>();
    public static  Environment instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        AddConsumptionEntry<Ewe, GloomRoot>();
        
    }
    private void AddConsumptionEntry<TPredator, TPrey>() where TPredator : Animal where TPrey : EntityBase
    {
        Type predatorType = typeof(TPredator);
        Type preyType = typeof(TPrey);
        if (consumptionDictionary.ContainsKey(predatorType))
        {
            // If it does, add the prey type to the existing list
            consumptionDictionary[predatorType].Add(preyType);
        }
        else
        {
            // If it doesn't, create a new list with the prey type and add it to the dictionary
            List<Type> preyList = new List<Type> { preyType };
            consumptionDictionary.Add(predatorType, preyList);
        }
    }

    public List<GameObject> FindPotentialFoodSource(Animal a, Collider[] colliders)
    {
        List<GameObject> validFoodSources = new List<GameObject>();

        if (a != null && colliders != null)
        {
            Type animalType = a.GetType();

            // Check if the animal's type is in the consumptionDictionary
            if (consumptionDictionary.ContainsKey(animalType))
            {
                List<Type> validFoodTypes = consumptionDictionary[animalType];

                foreach (Collider collider in colliders)
                {
                    // Check if the collider's GameObject has a component derived from EntityBase
                    EntityBase entity = collider.gameObject.GetComponent<EntityBase>();

                    if (entity != null && validFoodTypes.Contains(entity.GetType()))
                    {
                        // Valid food source found
                        validFoodSources.Add(collider.gameObject);
                    }
                }
            }
        }

        return validFoodSources;
    }



}
