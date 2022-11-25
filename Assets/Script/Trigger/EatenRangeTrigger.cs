using UnityEngine;

public class EatenRangeTrigger : MonoBehaviour
{
    Animator _animator;
    [SerializeField] LevelManager _levelManager;

    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            _audioSource.Play();
            _levelManager.LevelWon = true;
            _animator.SetTrigger("CandyEaten");
            _animator.SetBool("CandyClose", false);
            Destroy(collision.gameObject, 0.05f);

        }
    }
}
