using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectScript", menuName = "Scriptable Objects/ScriptableObjectScript")]
public class ScriptableObjectScript : ScriptableObject
{
    public float chunkSpeed = 2f;
    public int playerLives = 3;
    public int shardsCollected = 0;

}
