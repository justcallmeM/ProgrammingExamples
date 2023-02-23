namespace Concurrency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public async Task<T> WrapWithOdpOrgIdAsync<T>(Func<Task<T>> doApiCall, string opdOrgId = null)
        {
            try
            {
                if (doApiCall == null)
                {
                    throw new ArgumentNullException(nameof(doApiCall));
                }

                if (typeof(T) == typeof(Task))
                {
                    await (doApiCall as Func<Task>)();
                    return default(T);
                }
                else
                {
                    return await doApiCall();
                }
            }
            catch (Exception e)
            {
                Exception wrappedException = new Exception($"OdpOrgId = {opdOrgId}", e);
                throw wrappedException;
            }
        }
    }
}