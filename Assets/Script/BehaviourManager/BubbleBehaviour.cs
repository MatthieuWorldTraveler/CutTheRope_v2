using Assets.Script.BehaviourManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    GameObject _candy;
    Transform _transform;
    private void Awake()
    {
        _transform = transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Candy"))
        {
            _transform.gameObject.layer = 3;
            _candy = collision.gameObject;
            _candy.GetComponent<Rigidbody2D>().gravityScale = 0;
            _candy.GetComponent<CandyBehaviour>().IsInBubble = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Candy"))
            Destroy(gameObject);
    }

    private void Update()
    {
        if (_candy != null)
            _transform.position = _candy.transform.position;
    }

    private void OnDestroy()
    {
        if (_candy != null)
        {
            _candy.GetComponent<CandyBehaviour>().IsInBubble = false;
            _candy.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
