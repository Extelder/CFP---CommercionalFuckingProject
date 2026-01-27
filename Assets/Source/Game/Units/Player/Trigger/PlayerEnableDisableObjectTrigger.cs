using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnableDisableObjectTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player Player))
        {
            _gameObject.SetActive(true);
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player Player))
        {
            _gameObject.SetActive(false);
        }      
    }
}
