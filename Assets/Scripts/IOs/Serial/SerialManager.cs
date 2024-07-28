using UnityEngine;
using System.Collections;

public class SerialManager : MonoBehaviour
{
    static byte[] touchData = new byte[9] { 40, 0, 0, 0, 0, 0, 0, 0, 41 };
    static byte[] touchData2 = new byte[9] { 40, 0, 0, 0, 0, 0, 0, 0, 41 };

    void Start()
    {
        // TODO: Implement touch communication with backend.
    }

    public static void ChangeTouch(bool isP1, int Area, bool State)
    {
        if (isP1)
            ByteArrayExt.SetBit(touchData, Area + 8, State);
        else
            ByteArrayExt.SetBit(touchData2, Area + 8, State);
    }
}

public static class ByteArrayExt
{
    public static byte[] SetBit(this byte[] self, int index, bool value)
    {
        var bitArray = new BitArray(self);
        bitArray.Set(index, value);
        bitArray.CopyTo(self, 0);
        return self;
    }
}