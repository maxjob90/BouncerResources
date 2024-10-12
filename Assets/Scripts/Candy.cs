using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField] private OtherObjectManager _otherObjectManager;
    public Color Color { get; private set; }
    private Renderer _renderer;
    private Transform _transform;
    public bool triggerEnterOnSnowman;

    public void Initialize(ColorsProvider colorsProvider)
    {
        _transform = GetComponentInChildren<Transform>();
        _renderer = GetComponentInChildren<Renderer>();
        var color = colorsProvider.GetColor();
        _renderer.material.color = color;
        Color = color;
        _otherObjectManager.RandomPosition(_transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            other.GetComponent<Renderer>().materials[0].color = _renderer.material.color;
            triggerEnterOnSnowman = true;
        }

        
    }
}