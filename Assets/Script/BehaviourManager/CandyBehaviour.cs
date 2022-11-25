using System.Collections;
using UnityEngine;

namespace Assets.Script.BehaviourManager
{
    public class CandyBehaviour : MonoBehaviour
    {
        Rigidbody2D _rb;
        [SerializeField] float _forceBubble = 5f;

        public bool IsInBubble { get; set; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if(IsInBubble)
            {
                Vector2 force = new Vector2(0, _forceBubble);
                _rb.AddForce(force);
            }
        }
    }
}