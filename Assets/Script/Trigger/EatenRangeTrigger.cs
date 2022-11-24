using UnityEngine;

public class EatenRangeTrigger : MonoBehaviour
{
    Animator _animator;
    Transform _transform;
    [SerializeField] LevelManager _levelManager;

    private void Awake()
    {
        _transform = transform;
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            _levelManager.LevelWon = true;
            _animator.SetTrigger("CandyEaten");
            _animator.SetBool("CandyClose", false);
            Destroy(collision.gameObject, 0.05f);

        }
    }
}
