using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTrigger : MonoBehaviour
{
    [SerializeField] LevelManager _levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Candy"))
        {
            _levelManager.StarLoot();
            Destroy(this.gameObject);
        }
    }
}
