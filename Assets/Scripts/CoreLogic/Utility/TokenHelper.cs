using System.Threading;

namespace CoreLogic.Utility
{
    public static class TokenHelper
    {
        public static void Dispose(CancellationTokenSource token)
        {
            if (token == null) return;
            
            if (!token.IsCancellationRequested) token.Cancel();
            
            token.Dispose();
        }
    }
}