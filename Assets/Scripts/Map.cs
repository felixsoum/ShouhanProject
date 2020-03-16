using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject tileObject;

    [SerializeField] int rowCount = 10;
    [SerializeField] int columnCount = 10;

    [SerializeField] float spacing = 1;
    Vector3 originPosition;

    void Awake()
    {
        originPosition = tileObject.transform.position;
        for (int x = 0; x < columnCount; x++)
        {
            for (int y = 0; y < rowCount; y++)
            {
                if (x == 0 && y == 0)
                {
                    continue;
                }
                Instantiate(tileObject, IndicesToPosition(x, y), Quaternion.identity);
            }
        }
    }

    public Vector3 IndicesToPosition(int x, int y)
    {
        return originPosition + new Vector3(x * spacing, y * spacing, 0);
    }
}
