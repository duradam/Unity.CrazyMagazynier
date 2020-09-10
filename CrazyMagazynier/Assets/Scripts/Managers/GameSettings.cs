using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]

public class GameSettings : ScriptableObject
{
    [SerializeField]
    private string _gameVersion = "0.0.0";
    public string GameVersion { get { return _gameVersion; } }
    private string _nickName { get { return "Punki"; } }
    public string NickName { get {return _nickName + Random.Range(0, 9999).ToString(); } }
}
