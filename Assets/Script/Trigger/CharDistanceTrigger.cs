using UnityEngine;

public class CharDistanceTrigger : MonoBehaviour
{
    Animator _animator;
    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = transform.parent.GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            _audioSource.Play();
            _animator.SetBool("CandyClose", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
            _animator.SetBool("CandyClose", false);
    }
}
