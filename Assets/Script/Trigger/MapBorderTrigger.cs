using UnityEngine;
using UnityEngine.SceneManagement;


public class MapBorderTrigger : MonoBehaviour
{
    Animator _charAnim;

    const float _loseWaitTime = 1f;
    float _loseTimer;

    bool _gameLost;

    Animator _animator;
    AudioSource _audioSource;

    public bool Losed { get { return Time.time > _loseTimer; } }


    private void Start()
    {
        _audioSource = GetComponentInParent<AudioSource>();
        _charAnim = GameObject.FindGameObjectWithTag("Char").GetComponentInChildren<Animator>();
        _animator = transform.parent.GetComponentInChildren<Animator>();
        _animator.SetTrigger("Lost");
        _loseTimer = Time.time + _loseWaitTime;
    }

    private void Update()
    {
        if (!_gameLost)
            _loseTimer = Time.time + _loseWaitTime;

        if (Losed)
            ResetLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            _audioSource.Play();
            _gameLost = true;
            _charAnim.SetTrigger("CandyLost");
        }
    }

    public void ResetLevel()
    {
        string actualScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(actualScene);
    }
}
