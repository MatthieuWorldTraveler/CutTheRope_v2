using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapBorderTrigger : MonoBehaviour
{

    const float _loseWaitTime = .5f;
    float _loseTimer;

    bool _gameLost;

    Animator _animator;

    public bool Losed { get { return Time.time > _loseTimer; } }


    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
        _animator.SetTrigger("Lost");
        _loseTimer = Time.time + _loseWaitTime;
    }

    private void Update()
    {
        if(!_gameLost)
            _loseTimer = Time.time + _loseWaitTime;

        if (Losed)
            ResetLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Candy"))
        {
            _gameLost = true;
        }
    }

    public void ResetLevel()
    {
        string actualScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(actualScene);
    }
}
