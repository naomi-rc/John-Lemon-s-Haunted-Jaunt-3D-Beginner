using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Transform player;
    public Inventory inventory;
    AudioSource m_AudioSource;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_AudioSource.Play();
            Invoke("CollectKey", 1f); 
            inventory.AddKey();
        }
    }

    private void CollectKey()
    {
        gameObject.SetActive(false);
    }
}
