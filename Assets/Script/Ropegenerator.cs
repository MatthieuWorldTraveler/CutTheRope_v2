using System.Collections.Generic;
using UnityEngine;

public class Ropegenerator : MonoBehaviour
{
    [SerializeField] SegmentBehaviour _ropePrefab;
    [SerializeField] int _segmentNbr = 10;
    [SerializeField] GameObject _baseRope;
    [SerializeField] LineRenderer _cuttedRenderer;
    [SerializeField] float _vanishingSpeed = 0.4f;


    List<SegmentBehaviour> _ropes = new List<SegmentBehaviour>();
    List<SegmentBehaviour> _cuttedRopes = new List<SegmentBehaviour>();
    Rigidbody2D _candy;
    HingeJoint2D _joint;
    Transform _transform;
    LineRenderer _lineRenderer;

    [SerializeField] bool _isCutted;

    private void Awake()
    {
        _transform = transform;
        _joint = GetComponent<HingeJoint2D>();
        _candy = GameObject.FindGameObjectWithTag("Candy").GetComponent<Rigidbody2D>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        GenerateRope();
    }

    private void GenerateRope()
    {
        for (int i = 0; i < _segmentNbr; i++)
        {
            _ropes.Add(Instantiate(_ropePrefab, new Vector2(_transform.position.x, _transform.position.y), Quaternion.identity, _baseRope.transform));

            _ropes[i].SetRope(this);
            // If First segment 
            if (i == 0)
            {
                _joint.connectedBody = _ropes[i].Rigidbody;
            }
            // If any segments
            else
                _ropes[i - 1].Joint.connectedBody = _ropes[i].Rigidbody;
        }

        _ropes[_ropes.Count - 1].Joint.connectedBody = _candy;

        _ropes[_ropes.Count - 1].Joint.connectedAnchor = Vector2.zero;

        _lineRenderer.positionCount = _ropes.Count + 1;

    }

    // Affichage de la corde (LineRenderer)
    void Update()
    {
        _lineRenderer.SetPosition(0, _transform.position);

        // Puis pour chaque segment...
        for (int i = 0; i < _ropes.Count; i++)
        {
            // ... on d?finit un nouveau point de position pour la ligne
            _lineRenderer.SetPosition(i + 1, _ropes[i].Transform.position);
        }

        if (_isCutted)
        {
            // Idem pour les segments de la partie coupée
            for (int i = 0; i < _cuttedRopes.Count; i++)
            {
                _cuttedRenderer.SetPosition(i, _cuttedRopes[i].Transform.position);
            }

            ApplyVanishing();
        }
    }
    private void ApplyVanishing()
    {
        //    // Si la disparition n'est pas terminée
        //    if (!Mathf.Approximately(_lineRenderer.colorGradient.alphaKeys[0].alpha, 0f))
        //    {
        //        // On réduit progressivement les clefs alpha des gradients des LineRenderers
        //        Gradient copyGradient = _lineRenderer.colorGradient;
        //        GradientAlphaKey[] alphaArray = copyGradient.alphaKeys;
        //        alphaArray[0].alpha -= _vanishingSpeed * Time.deltaTime;
        //        alphaArray[1].alpha -= _vanishingSpeed * Time.deltaTime;
        //        copyGradient.alphaKeys = alphaArray;
        //        _lineRenderer.colorGradient = copyGradient;

        //        copyGradient = _cuttedLineRenderer.colorGradient;
        //        alphaArray = copyGradient.alphaKeys;
        //        alphaArray[0].alpha -= _vanishingSpeed * Time.deltaTime;
        //        alphaArray[1].alpha -= _vanishingSpeed * Time.deltaTime;
        //        copyGradient.alphaKeys = alphaArray;
        //        _cuttedLineRenderer.colorGradient = copyGradient;
        //    }
        //    // Sinon (la disparition est terminée)
        //    else
        //    {
        //        // On détruit tous les segments
        DestroyAllSegments();
        //    }
    }

    // On détruit tous les segments
    private void DestroyAllSegments()
    {
        for (int i = 0; i < _ropes.Count; i++)
        {
            Destroy(_ropes[i]);
        }
    }

    public void Cut(SegmentBehaviour segment)
    {
        if (!_isCutted)
        {
            _isCutted = true;
            int cuttedIndex = _ropes.IndexOf(segment);
            _ropes.RemoveAt(cuttedIndex);
            Destroy(segment.gameObject);

            _cuttedRopes = _ropes.GetRange(cuttedIndex, _ropes.Count - cuttedIndex);
            _ropes = _ropes.GetRange(0, cuttedIndex);

            _lineRenderer.positionCount = _ropes.Count + 1;
            _cuttedRenderer.positionCount = _cuttedRopes.Count;
        }
    }
}
