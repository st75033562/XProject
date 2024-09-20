using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StringProtoc<T> : IProtoc<T> {
    public void DealWith(byte[] data, int start, int length) {

        string result = System.Text.Encoding.UTF8.GetString(data, start, length);
    }

    public T DequeueData() {
        throw new System.NotImplementedException();
    }
}
