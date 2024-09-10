using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProtoc
{
    void DealWith(byte[] data, int start, int length);
}
