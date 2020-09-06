using System;

namespace Painter
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var painter = new Painter())
                painter.Run();
        }
    }
}
