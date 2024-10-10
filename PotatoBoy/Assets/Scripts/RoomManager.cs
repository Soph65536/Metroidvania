using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject virtualCamera;

    [SerializeField] private Vector3 RoomSpawn;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player") && !collider.isTrigger)
        {
            virtualCamera.SetActive(true);
            GameManager.Instance.SpawnPosition = RoomSpawn;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !collider.isTrigger)
        {
            virtualCamera.SetActive(false);
        }
    }
}
