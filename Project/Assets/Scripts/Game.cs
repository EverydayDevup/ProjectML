using Cysharp.Threading.Tasks;
using EDD;
using UnityEngine;

public class Game : MonoSingleton<Game>
{
    // 임시 테스트를 위한 링크
    [SerializeField] private Stage stage;
    [SerializeField] public Player player;
    
    public Stage Stage => stage;
    
    private void Awake()
    {
        
    }
}
