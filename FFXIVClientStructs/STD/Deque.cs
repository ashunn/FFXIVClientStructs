﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.STD
{
    [StructLayout(LayoutKind.Sequential, Size = 0x28)]
    public unsafe struct StdDeque<T> where T : unmanaged
    {
        public void* ContainerBase; // iterator base nonsense
        public T** Map; // pointer to array of pointers (size MapSize) to arrays of T (size BlockSize)
        public ulong MapSize; // size of map
        public ulong MyOff; // offset of current first element
        public ulong MySize; // current length 

        public int BlockSize() => 
            sizeof(T) <= 1 ? 16 :
            sizeof(T) <= 2 ? 8 :
            sizeof(T) <= 4 ? 4 :
            sizeof(T) <= 8 ? 2 : 
            1;
    }
}