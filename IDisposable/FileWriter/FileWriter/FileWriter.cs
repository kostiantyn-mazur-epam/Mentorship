using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace Convestudo.Unmanaged
{
    public class FileWriter : IFileWriter, IDisposable
    {
        private const uint _HRESULT_SUCCESS = 0x80070000;

        private SafeFileHandle _safeHandle;

        [DllImport("KERNEL32", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern SafeFileHandle CreateFile(string lpFileName, DesiredAccess dwDesiredAccess, ShareMode dwShareMode, IntPtr lpSecurityAttributes, CreationDisposition dwCreationDisposition, FlagsAndAttributes dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("KERNEL32", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool WriteFile(SafeFileHandle hFile, byte[] aBuffer, uint cbToWrite, ref uint cbThatWereWritten, IntPtr pOverlapped);

        private void ThrowLastWin32Err()
        {
            var hresult = Marshal.GetHRForLastWin32Error();

            if (hresult != unchecked((int)_HRESULT_SUCCESS))
            {
                Marshal.ThrowExceptionForHR(hresult);
            }
        }

        public FileWriter(string fileName)
        {
            _safeHandle = CreateFile(
                fileName,
                DesiredAccess.Write,
                ShareMode.None,
                IntPtr.Zero,
                CreationDisposition.CreateAlways,
                FlagsAndAttributes.Normal,
                IntPtr.Zero);

            ThrowLastWin32Err();
        }

        public void Write(string str)
        {
            var bytes = GetBytes(str);
            var bytesWritten = 0U;
            WriteFile(_safeHandle, bytes, (uint)bytes.Length, ref bytesWritten, IntPtr.Zero);
        }

        public void WriteLine(string str)
        {
            Write(string.Format("{0}{1}", str, Environment.NewLine));
        }

        /// <summary>
        /// Converts string to byte array
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>

        private static byte[] GetBytes(string str)
        {
            return Encoding.Unicode.GetBytes(str);
        }

        public void Dispose()
        {
            _safeHandle.Dispose();
        }
    }
}