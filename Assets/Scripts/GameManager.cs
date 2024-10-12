using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ColorsProvider _colorsProvider;
    [SerializeField] private Snowman _snowman;
    [SerializeField] private Present _present;
    [SerializeField] private Candy _candy;
    [SerializeField] private int _quantityPresents;

    private void Awake()
    {
        _candy.Initialize(_colorsProvider);
        _present.Initialize(_colorsProvider, _quantityPresents);
    }

    private void Update()
    {
        if (_candy.triggerEnterOnSnowman)
        {
            _candy.Initialize(_colorsProvider);
            _candy.triggerEnterOnSnowman = false;
        }

        if (_snowman._collisionEnterOnPresent)
        {
            _snowman._collisionEnterOnPresent = false;
        }
    }
}