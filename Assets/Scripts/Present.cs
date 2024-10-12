using UnityEngine;

public class Present : MonoBehaviour
{
    [SerializeField] private GameObject _present;
    [SerializeField] private OtherObjectManager _otherObjectManager;
    private GameObject[] presents;

    public void Initialize(ColorsProvider colorsProvider, int quantityPresents)
    {
        presents = new GameObject[quantityPresents];
        for (var i = 0; i < presents.Length; i++)
        {
            presents[i] = Instantiate(_present);
            Renderer renderer = presents[i].transform.GetChild(0).GetComponent<Renderer>();
            renderer.materials[1].color = colorsProvider.GetColor();

            _otherObjectManager.RandomPosition(presents[i].GetComponent<Transform>());

            if (IsPlacementValid(presents[i].transform.position, presents[i].GetComponent<BoxCollider>().size))
            {
                while (IsPlacementValid(presents[i].transform.position, presents[i].GetComponent<BoxCollider>().size))
                {
                    _otherObjectManager.RandomPosition(presents[i].GetComponent<Transform>());
                    IsPlacementValid(presents[i].transform.position, presents[i].GetComponent<BoxCollider>().size);
                }
            }
        }
    }

    private bool IsPlacementValid(Vector3 position, Vector3 size)
    {
        Collider[] hitColliders = Physics.OverlapBox(position, size/2f , Quaternion.identity);
        return hitColliders.Length != 2;
    }
}