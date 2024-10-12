using UnityEngine;
using Random = UnityEngine.Random;

public class OtherObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameBoard;

    public void RandomPosition(Transform transform)
    {
        var size = _gameBoard.GetComponent<BoxCollider>().size;
        var center = _gameBoard.GetComponent<BoxCollider>().center;

        var randomX = Random.Range(center.x - size.x, center.x + size.x);
        var randomZ = Random.Range(center.z - size.z, center.z + size.z);

        transform.position = new Vector3(randomX, 0, randomZ);
    }

    public void LockPositionWithinGameBoard(GameObject gameObject)
    {
        // Получаем коллайдер gameBoard
        var boardCollider = _gameBoard.GetComponent<BoxCollider>();

        var halfSizeCollider = gameObject.GetComponent<BoxCollider>().size.x / 2f;

        // Проверяем, где сейчас находится объект
        Vector3 newPosition = gameObject.transform.position;

        // Проверяем границы коллайдера
        Vector3 boardMin = boardCollider.bounds.min;
        Vector3 boardMax = boardCollider.bounds.max;

        // Ограничиваем коррекцию позиции
        newPosition.x = Mathf.Clamp(newPosition.x, boardMin.x + halfSizeCollider, boardMax.x - halfSizeCollider);
        newPosition.z = Mathf.Clamp(newPosition.z, boardMin.z + halfSizeCollider, boardMax.z - halfSizeCollider);

        gameObject.transform.position = newPosition; // Обновляем позицию объекта
    }
}