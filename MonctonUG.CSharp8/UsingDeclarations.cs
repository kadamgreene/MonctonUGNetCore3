using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonctonUG.CSharp8
{
    public class UsingDeclarations
    {
        public static void Run()
        {
            using var file = new FileWrapper("lines.txt");
            int lines = 0;
            while (!String.IsNullOrEmpty(file.ReadLine()))
            {
                lines++;
            }
            Console.WriteLine($"There are {lines}");
        }
    }

    public class FileWrapper : IDisposable
    {
        private StreamReader _reader;

        public FileWrapper(string filename)
        {
            Console.WriteLine($"{nameof(FileWrapper)} created");
            _reader = new StreamReader(filename);
        }

        public string ReadLine()
        {
            return _reader.ReadLine();
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _reader.Dispose();
                    Console.WriteLine($"{nameof(FileWrapper)} disposed");
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~FileWrapper()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
