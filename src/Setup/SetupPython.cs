using Python.Runtime;
using System;
using System.IO;

namespace Morris.Setup {
    public class SetupPython {
        public static void setup_py_venv_003() {
            Runtime.PythonDLL = @"C:\Python\Python312\python312.dll";
            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", Runtime.PythonDLL);
        }
    }
}