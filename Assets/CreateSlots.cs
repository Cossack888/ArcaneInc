using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSlots : MonoBehaviour
{   [SerializeField] int amountOfSlots;
    [SerializeField] GameObject slotPrefab;
    void Start()
    {
        for(int i = 0; i < amountOfSlots; i++)
        {
            GameObject createdGO = Instantiate(slotPrefab, gameObject.transform);
            createdGO.hideFlags = HideFlags.HideInHierarchy;
        }
    }

}
