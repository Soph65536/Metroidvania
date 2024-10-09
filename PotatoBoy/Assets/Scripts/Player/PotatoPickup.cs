using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.boomerangRenderer.enabled = true;
            GameManager.Instance.gotBoomerang = true;
            Destroy(gameObject);
        }
            
    }
}
