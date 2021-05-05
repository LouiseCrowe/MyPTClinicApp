using System.Threading;

namespace MyPTClinicAppWebDriverTests
{
    internal static class TestHelper
    {
        ///// <summary>
        ///// Brief delay to slow down browser interactions for
        ///// demo video recording purposes
        ///// </summary>
        public static void Pause(int secondsToPause = 5000)
        {
            Thread.Sleep(secondsToPause);
        }
    }
}
