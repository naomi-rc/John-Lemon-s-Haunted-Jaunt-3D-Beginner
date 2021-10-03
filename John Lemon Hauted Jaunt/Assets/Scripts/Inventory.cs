using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Transform[] keys;
    public Text keysCountText; 
    int m_CollectedKeyCount = 0;

    public void Start()
    {
        keysCountText.text = $"Keys 0/5";
    }

    public void AddKey()
    {
        m_CollectedKeyCount++;
        keysCountText.text = $"Keys: {m_CollectedKeyCount}/{keys.Length}";
    }

    public bool CollectedAllKeys()
    {
        return m_CollectedKeyCount == keys.Length;
    }

    public void Reset()
    {
        m_CollectedKeyCount = 0;
        keysCountText.text = $"Keys 0/5";
    }


}
