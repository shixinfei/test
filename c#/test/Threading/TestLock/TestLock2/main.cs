﻿namespace TestLock2
{
    class Program
    {
        static void Main()
        {
            var _lock = new object();

            lock(_lock)
            {}
        }
    }
}
