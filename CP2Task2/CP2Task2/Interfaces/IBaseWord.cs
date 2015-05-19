using System.Collections;

namespace CP2Task2.Interfaces
{
    interface IBaseWord
    {
        char Letter { get; }
        string Word { get; }
        int Amount { get; }
        ArrayList Lines { get; }
    }
}
