using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProtoc<T> {
    void DealWith(byte[] data, int start, int length);

    T DequeueData();
}
