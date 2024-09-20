using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginMsg : Singleton<LoginMsg>, IMsg {
    public LoginS2C loginS2c { get; set; }

    public void Reset() {
        throw new System.NotImplementedException();
    }
}
