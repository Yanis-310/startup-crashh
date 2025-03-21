using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections;


public class PlayerManager : MonoBehaviour
{
    public Transform spawnPoint; 
    public float timeForHit = 0.5f; 
    private int warnings = 0; 
    private bool canHit = true;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(!canHit)
        {
            return;
        }
        if (other.CompareTag("Boss")) 
        {
            canHit = false;
            StartCoroutine(WaitForHit());
            warnings++;
            Debug.Log($"Touch {warnings}");
            if (warnings >= 3) 
            {
                Debug.Log($"Touch if {warnings}");
                SceneManager.LoadScene("GameOver"); 
            }
            else
            {
                Debug.Log($"Touch else {warnings}");
                StartCoroutine(ResetPlayerPosition());
            }
        }
    }

    IEnumerator ResetPlayerPosition()
    {
        PlayerController controller = GetComponent<PlayerController>();
        controller.enabled = false;
        yield return null;
        transform.position = spawnPoint.position;
        yield return null;
        controller.enabled = true;
    }

    IEnumerator WaitForHit(){
        yield return new WaitForSeconds(timeForHit);
        canHit = true;
    }
}
