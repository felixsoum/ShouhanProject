using UnityEngine;

enum Move
{
    Down,
    Right,
    Up,
    Left
}

public class MapCharacter : MonoBehaviour
{
    public bool IsControllable { get; set; }
    [SerializeField] Map map;
    [SerializeField] GameObject orientationObject;

    public MapCharacter NextCharacter { get; set; }

    int currentX;
    int currentY;
    private Move? previousMove;
    const float MoveSpeed = 0.5f;

    void Update()
    {
        GetPlayerInput();

        transform.position =
            Vector3.MoveTowards(transform.position, GetTargetPosition(), Time.deltaTime * MoveSpeed);
    }

    private void GetPlayerInput()
    {
        if (!IsControllable || Vector3.Distance(transform.position, GetTargetPosition()) > 0.01f)
        {
            return;
        }

        Move? move = null;

        if (Input.GetKey(KeyCode.W))
        {
            move = Move.Up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move = Move.Down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            move = Move.Left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move = Move.Right;
        }

        if (move.HasValue)
        {
            ApplyMove(move.Value);
        }
    }

    private void ApplyMove(Move move)
    {
        if (NextCharacter != null && previousMove.HasValue)
        {
            NextCharacter.ApplyMove(previousMove.Value);
        }

        SetOrientation(move);

        switch (move)
        {
            case Move.Down:
                currentY--;
                break;
            case Move.Right:
                currentX++;
                break;
            case Move.Up:
                currentY++;
                break;
            case Move.Left:
                currentX--;
                break;
        }
    }

    private Vector3 GetTargetPosition()
    {
        return map.IndicesToPosition(currentX, currentY);
    }

    void SetOrientation(Move move)
    {
        previousMove = move;
        orientationObject.transform.localEulerAngles = new Vector3(0, 0, (int)move * 90);
    }
}
