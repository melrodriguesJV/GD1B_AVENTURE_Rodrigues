using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            //give score to player
            Destroy(gameObject);
        }
    }
}
