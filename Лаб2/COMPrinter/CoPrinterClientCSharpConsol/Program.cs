using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using DISPPARAMS = System.Runtime.InteropServices.ComTypes.DISPPARAMS;
using INVOKEKIND = System.Runtime.InteropServices.ComTypes.INVOKEKIND;
namespace CoPrinterClientCSharpConsol
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
            int GetTypeInfo([In, MarshalAs(UnmanagedType.U4)] UInt32 iTInfo, [In, MarshalAs(UnmanagedType.U4)] UInt32 lcid, ref ITypeInfo typeInfo);
            int GetIDsOfNames([In] ref Guid riid, [In, MarshalAs(UnmanagedType.LPArray)] string[] rgszNames, [In, MarshalAs(UnmanagedType.U4)] int cNames, 
                              [In, MarshalAs(UnmanagedType.U4)] int lcid, [Out, MarshalAs(UnmanagedType.LPArray)] int[] rgDispId);
            int Invoke([In, MarshalAs(UnmanagedType.U4)] int dispIdMember, [In] ref Guid riid, [In, MarshalAs(UnmanagedType.U4)] int lcid,
                       INVOKEKIND wFlags, ref DISPPARAMS Params,  out object pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
        };

        [STAThread]
        static void Main(string[] args)
        { 
            // Получаем интерфейс IDispatch
            IDispatch disp = (IDispatch)(new Printer());

            // Получаем число интерфейсов информации типа
            int a = 0;
            disp.GetTypeInfoCount(out a);

            // Массив названий методов
            var namesMaethos = new string[] { "SpeedUp", "QualityUp", "GetMaxSpeed", "GetCurSpeed", "GetCurQuality",
                                              "SetPetName", "SetMaxSpeed", "GetPetName" , "DisplayStats" };
            // Массив id методов 
            int[] IDs = new int[namesMaethos.Length];

            // Пустой гуид
            Guid guid = new Guid();

            // Получаем массив соответсвующих ID
            disp.GetIDsOfNames(ref guid,  namesMaethos, namesMaethos.Length, 1, IDs);

            // Коллекция: ключ - имя метода, значение - ID
            int i = 0;
            var methodsDict = namesMaethos.ToDictionary(k => k, v => IDs[i++]);

            // Выведем полученные ID
            Console.WriteLine(string.Format("{0, -15} | {1}", "Method name", "ID"));
            foreach (var elem in methodsDict)
                Console.WriteLine(string.Format("{0, -15} | {1}", elem.Key, elem.Value));
            Console.WriteLine("--------------------------");

            // Для получения результата из Get функций 
            object result;

            // Последние 2 параметра для Invoke
            var pExcepInfo = new IntPtr();
            var puArgErr = new IntPtr();

            // 4-й параметр для Invoke
            INVOKEKIND wFlags = new INVOKEKIND();

            // Переменная для передачи аргументов в Set функции 
            var pVariant = Marshal.AllocCoTaskMem(10);

            // Преобразуем строку в VARIANT
            Marshal.GetNativeVariantForObject("HP", pVariant);

            // Структура параметров
            DISPPARAMS param = new DISPPARAMS()
            {
                cArgs = 1,
                cNamedArgs = 0,
                rgdispidNamedArgs = IntPtr.Zero,
                rgvarg = pVariant
            };

            // Привсваиваем имя 
            disp.Invoke(methodsDict["SetPetName"], guid, 1, wFlags, param, out result, pExcepInfo, puArgErr);

            Marshal.GetNativeVariantForObject(10, pVariant);
            param.rgvarg = pVariant;

            // Привсваиваем максимальную скорость
            disp.Invoke(methodsDict["SetMaxSpeed"], guid, 1, wFlags, param, out result, pExcepInfo, puArgErr);

            // Получаем текущую скорость
            disp.Invoke(methodsDict["GetCurSpeed"], guid, 1, wFlags, param, out result, pExcepInfo, puArgErr);
            Console.WriteLine("Current speed: " + result.ToString());
            int curSpeed = Convert.ToInt32(result);

            // Получаем текущее качество
            disp.Invoke(methodsDict["GetCurQuality"], guid, 1, wFlags, param, out result, pExcepInfo, puArgErr);
            Console.WriteLine("Current quality: " + result.ToString());

            // Получаем максимальную скорость
            disp.Invoke(methodsDict["GetMaxSpeed"], guid, 1, wFlags, param, out result, pExcepInfo, puArgErr);
            int maxSpeed = Convert.ToInt32(result);

            Console.WriteLine("-------------------------");

            for (; curSpeed < maxSpeed; curSpeed++)
            {
                disp.Invoke(methodsDict["SpeedUp"], guid, 1, wFlags, param, out result, pExcepInfo, puArgErr);
                Console.WriteLine("SpeedUp! (+1)");
            }

            Console.WriteLine("-------------------------");
        
            // Получаем текущую скорость
            disp.Invoke(methodsDict["GetCurSpeed"], guid, 1, wFlags, param, out result, pExcepInfo, puArgErr);
            Console.WriteLine("Current speed: " + result.ToString());

            // Получаем текущее качество
            disp.Invoke(methodsDict["GetCurQuality"], guid, 1, wFlags, param, out result, pExcepInfo, puArgErr);
            Console.WriteLine("Current quality: " + result.ToString());

            // Выводим информацию об объекте
            disp.Invoke(methodsDict["DisplayStats"], guid, 1, wFlags, param, out result, pExcepInfo, puArgErr);

            Console.ReadKey();
        }
    }
}