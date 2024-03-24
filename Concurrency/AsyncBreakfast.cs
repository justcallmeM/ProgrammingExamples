namespace Concurrency
{
    public class AsyncBreakfast
    {
        // These classes are intentionally empty for the purpose of this example.
        // They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
        internal class Bacon { }
        internal class Coffee { }
        internal class Egg { }
        internal class Juice { }
        internal class Toast { }

        public static async Task MakeBreakfast()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2);

            Egg eggs = await eggsTask;
            Console.WriteLine("eggs are ready");

            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready");

            Toast toast = await toastTask;
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");

            Console.WriteLine("Breakfast is ready!");
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);

            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }

            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;

            static void ApplyButter(Toast toast)
                => Console.WriteLine("Putting butter on the toast");

            static void ApplyJam(Toast toast)
                => Console.WriteLine("Putting jam on the toast");

            static async Task<Toast> ToastBreadAsync(int slices)
            {
                for (int slice = 0; slice < slices; slice++)
                {
                    Console.WriteLine("Putting a slice of bread in the toaster");
                }

                Console.WriteLine("Start toasting...");
                await Task.Delay(3000);
                Console.WriteLine("Remove toast from toaster");

                return new Toast();
            }
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }
    }

    enum State { NotInitialized, Loading, Ready };

    internal class ElementRenderer
    {
        private State state;

        public ElementRenderer()
        {
            _ = InitializeGraphics(); // discard the await, we don't need it here, just continue executing the constructor.
        }

        async Task InitializeGraphics()
        {
            if (state != State.NotInitialized) return;
            state = State.Loading;

            Task loadMaterialsTask = LoadMaterials(); // return from InitializeGraphics now; the rest will run later.
            Task loadModelsTask = LoadModels();

            //maybe do something else here?

            await loadMaterialsTask;
            await loadModelsTask;

            AssignMaterialsToModels(); // this will not run until LoadModels completes

            state = State.Ready;
        }

        async Task LoadMaterials() { }

        async Task LoadModels() { }

        void AssignMaterialsToModels() { }

        public void Render()
        {
            if (state == State.Ready)
            {
                // render element
            }
        }
    }
}
