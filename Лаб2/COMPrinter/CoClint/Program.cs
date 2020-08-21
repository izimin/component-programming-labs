using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace CoClint
{
    class Program
    {
        [ComVisible(true)]
        [ComImport, Guid("3C393219-FFBB-4947-A0DF-3FA7A1E0780D")]
        public class Printer { }

        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("4C336B25-233C-47E1-80DC-A578ED11D0AA")]
        public interface IDispatch
        {
            int GetTypeInfoCount(out int Count);
            int GetTypeInfo([In, MarshalAs(UnmanagedType.U4)] UInt32 iTInfo, [In, MarshalAs(UnmanagedType.U4)] UInt32 lcid, 
                ref ITypeInfo typeInfo);
            int GetIDsOfNames([In] ref Guid riid, [In, MarshalAs(UnmanagedType.LPArray)] string[] rgszNames,
                              [In, MarshalAs(UnmanagedType.U4)] int cNames, [In, MarshalAs(UnmanagedType.U4)] int lcid,
                              [Out, MarshalAs(UnmanagedType.LPArray)] int[] rgDispId);
            int Invoke([In, MarshalAs(UnmanagedType.U4)] int dispIdMember, [In] ref Guid riid,
                        [In, MarshalAs(UnmanagedType.U4)] int lcid,
                        System.Runtime.InteropServices.ComTypes.INVOKEKIND wFlags,
                        ref System.Runtime.InteropServices.ComTypes.DISPPARAMS Params,
                        out object pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
        };

        [STAThread]
        static void Main(string[] args)
        {
            IDispatch disp = (IDispatch)(new Printer());

            int a = 0;
            disp.GetTypeInfoCount(out a);
            var id = new int[6];
            disp.GetIDsOfNames(new Guid(), new string[] { "SetPetName", "DisplayStats", "SetMaxSpeed", "GetMaxSpeed", "GetCurSpeed", "SpeedUp" },
                6, 1,  id);

            var pParam = Marshal.AllocCoTaskMem(15);
            Marshal.GetNativeVariantForObject("HP", pParam);
            object res = 0;
            System.Runtime.InteropServices.ComTypes.DISPPARAMS param = new System.Runtime.InteropServices.ComTypes.DISPPARAMS()
            {
                cArgs = 1,
                cNamedArgs = 0,
                rgdispidNamedArgs = IntPtr.Zero,
                rgvarg = pParam
            };
            disp.Invoke(id[0], new Guid(), 1, new System.Runtime.InteropServices.ComTypes.INVOKEKIND(), param, out res, new IntPtr(), new IntPtr());
            Marshal.GetNativeVariantForObject("20", pParam);
            param.rgvarg = pParam;
            disp.Invoke(id[2], new Guid(), 1, new System.Runtime.InteropServices.ComTypes.INVOKEKIND(), param, out res, new IntPtr(), new IntPtr());
            disp.Invoke(id[1], new Guid(), 1, new System.Runtime.InteropServices.ComTypes.INVOKEKIND(), param, out res, new IntPtr(), new IntPtr());
            disp.Invoke(id[4], new Guid(), 1, new System.Runtime.InteropServices.ComTypes.INVOKEKIND(), param, out res, new IntPtr(), new IntPtr());
            Console.WriteLine("Cur speed = " + res.ToString());
            disp.Invoke(id[5], new Guid(), 1, new System.Runtime.InteropServices.ComTypes.INVOKEKIND(), param, out res, new IntPtr(), new IntPtr());
            disp.Invoke(id[4], new Guid(), 1, new System.Runtime.InteropServices.ComTypes.INVOKEKIND(), param, out res, new IntPtr(), new IntPtr());
            Console.WriteLine("Cur speed = " + res.ToString());

            Console.ReadKey();
        }
    }
}
