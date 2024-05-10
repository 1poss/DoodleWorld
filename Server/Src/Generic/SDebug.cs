using System.Diagnostics;

namespace DoodleWorldServer {

    public static class SDebug {

        public static void Log(string message) {
            string info = GetInfo();
            System.Console.WriteLine($"{message}\r\n{info}");
        }

        public static void Warning(string message) {
            string info = GetInfo();
            // Color
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine($"{message}\r\n{info}");
            Console.ResetColor();
        }

        public static void Error(string message) {
            string info = GetInfo();
            // Color
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"{message}\r\n{info}");
            Console.ResetColor();
        }

        static string GetInfo() {
            string info = "";
            var trace = new StackTrace(2, true);
            StackFrame[] frames = trace.GetFrames();
            for (int i = 0; i < frames.Length; i++) {
                StackFrame frame = frames[i];
                string filename = frame.GetFileName();
                int line = frame.GetFileLineNumber();
                info += $" -> {filename}:{line}\r\n";
            }
            return info;
        }

    }

}