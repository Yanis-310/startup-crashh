using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant est la tasse
        if (other.CompareTag("tasse"))
        {
            Debug.Log("La tasse est posée sur le bureau !");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
