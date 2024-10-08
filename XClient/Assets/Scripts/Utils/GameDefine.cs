using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDefine : Singleton<GameDefine>
{
    public MonoBehaviour Mono { get; set; }

    public void Init(MonoBehaviour momo) {
        Mono = momo;
    }
    
}
