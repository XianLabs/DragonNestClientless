using System;
using System.Runtime.InteropServices;

namespace DragonLib.Network
{
}

    public static class Crypto
    {
    [DllImport("DragonCrypto.dll", EntryPoint = "EncryptTCP", CallingConvention = CallingConvention.Cdecl)]
    public static extern void EncryptTCP(byte[] data);
    [DllImport("DragonCrypto.dll", EntryPoint = "DecryptTCP", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DecryptTCP(byte[] data);
}     