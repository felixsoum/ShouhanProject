using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] MapCharacter[] mapCharacters;

    void Awake()
    {
        mapCharacters[0].IsControllable = true;
        for (int i = 1; i < mapCharacters.Length; i++)
        {
            mapCharacters[i - 1].NextCharacter = mapCharacters[i];
        }
    }
}
