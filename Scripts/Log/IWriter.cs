// ReSharper disable CheckNamespace

namespace AvalonAssets.Log
{
    public interface IWriter
    {
        void Write(string message);
        void Write(string message, string hexColor);
    }
}