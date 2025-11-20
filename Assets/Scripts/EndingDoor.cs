using UnityEngine;

public class EndingDoor : MonoBehaviour
{
    [SerializeField] private MenuManagerBehaviour menuManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            menuManager.EndGame();
    }
}
