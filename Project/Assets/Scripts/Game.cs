using Cysharp.Threading.Tasks;
using EDD;
using UnityEngine;

public class Game : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.ChangeScene("Title").Forget();
    }
}
