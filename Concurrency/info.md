The composition of an asynchronous operation followed by synchronous work is an **asynchronous** operation. 
<br/>Stated another way, if any portion of an operation is asynchronous, the entire operation is asynchronous.

The await operator gives up control of the main thread to the parent holder

The await operator suspends evaluation of the enclosing async method until the asynchronous operation 
<br/>represented by its operand completes. When the asynchronous operation completes, the await operator returns the result
<br/>of the operation, if any.

Key **pieces** to understand:
- Async code can be used for both I/O-bound and CPU-bound code, but differently for each scenario.

- Async code uses Task<T> and Task, which are constructs used to model work being done in the background.

- The async keyword turns a method into an async method, which allows you to use the await keyword in its body.

- When the await keyword is applied, it suspends the calling method and yields control back to its caller until the 
<br/> awaited task is complete.

- await can only be used inside an async method.



> #### Here are two questions you should ask before you write any code:

> - Will your code be "waiting" for something, such as data from a database?\
>	If your answer is **yes**, then your work is I/O-bound.
> 
> - Will your code be performing an expensive computation?\
> 	If you answered **yes**, then your work is CPU-bound.
> 
> - If the work you have is I/O-bound,\
> 	use async and await without Task.Run. You should not use the Task Parallel Library.
> 
> - If the work you have is CPU-bound and you care about responsiveness,\
> 	use async and await, but spawn off the work on another thread with Task.Run. 
>   If the work is appropriate for concurrency and parallelism, also consider using the Task Parallel Library.




	Async/Await:
	Async/await is a programming model that helps manage asynchronous operations in a more readable and structured manner.
	Asynchronous programming is used to perform non-blocking operations, such as I/O-bound tasks (e.g., reading/writing files, making network requests).
	async keyword is used to define a method as asynchronous, and await keyword is used to pause the execution of the
	method until an awaited task completes.
	Async methods return a Task or Task<T> representing the ongoing operation, allowing the caller to continue other 
	work in the meantime.
	Avoid using async void except for event handlers; prefer async Task or async Task<T> for better error handling and 
	composability.

	Concurrency:
	Concurrency is the concept of executing multiple tasks or operations in overlapping time periods, even if they are 
	not necessarily executed simultaneously.
	C# provides various constructs for managing concurrency, such as Task, ThreadPool, and Parallel class.
	Task represents an asynchronous operation that may run concurrently. It utilizes the thread pool to manage its execution.
	The Parallel class provides high-level constructs for parallelizing loops and executing tasks concurrently.
	
	Multithreading:
	Multithreading involves running multiple threads in a single process, allowing tasks to be executed in parallel.
	Threads are lightweight units of execution managed by the operating system or the thread pool. They share the same 
	memory space within a process.
	While multithreading can improve performance, it introduces challenges like thread synchronization, race conditions, 
	and deadlocks.
	C# offers classes like Thread for low-level multithreading, but higher-level constructs like Task and async/await 
	are often preferred for managing concurrency.

	Thread Safety and Synchronization:
	Ensuring thread safety is crucial when multiple threads access shared resources concurrently to prevent data corruption 
	and inconsistent behavior.
	Synchronization mechanisms like locks (lock statement), mutexes, semaphores, and monitors are used to control access 
	to shared resources and prevent race conditions.
	
	Parallelism:
	Parallelism focuses on breaking down a task into smaller subtasks that can be executed concurrently.
	The Parallel class and PLINQ (Parallel Language Integrated Query) enable easy parallel processing of collections 
	and iterative operations.
	
	Async/Await vs. Multithreading:
	Async/await is suitable for I/O-bound tasks and asynchronous operations that don't require CPU-bound processing.
	Multithreading is suitable for CPU-bound tasks that can benefit from parallel processing and require significant 
	computational work.
	
	Best Practices:
	Use async/await for I/O-bound operations to maintain responsiveness.
	Be cautious when accessing shared resources from multiple threads; use synchronization mechanisms.
	Avoid blocking on async code using .Result or .Wait() to prevent deadlocks.
	Profile and test your code to find the right balance between async and synchronous operations.
	Remember that while these concepts offer powerful ways to manage concurrency, they can also introduce complexity. 
	Understanding the trade-offs and choosing the right approach for your specific use case is important for writing 
	efficient and reliable code.


>    Important info and advice
>    With async programming, there are some details to keep in mind that can prevent unexpected behavior:
>    - async void should only be used for event handlers.
>    - async void is the only way to allow asynchronous event handlers to work because events do not have return types\
>	(thus cannot make use of Task and Task\<T\>). Any other use of async void does not follow the TAP model and can be\ 
> 	challenging to use, such as:
>        - Exceptions thrown in an async void method can't be caught outside of that method.
>        - async void methods are difficult to test.
>        - async void methods can cause bad side effects if the caller isn't expecting them to be async.
>    - Tread carefully when using async lambdas in LINQ expressions
>        - Lambda expressions in LINQ use deferred execution, meaning code could end up executing at a time when you're\
>		not expecting it to. The introduction of blocking tasks into this can easily result in a deadlock if not written\
>		correctly. Additionally, the nesting of asynchronous code like this can also make it more difficult to reason\
>		about the execution of the code. Async and LINQ are powerful but should be used together as carefully and clearly as possible.
>    - Write code that awaits Tasks in a non-blocking manner
>		Blocking the current thread as a means to wait for a Task to complete can result in deadlocks and blocked context\ 
>		threads and can require more complex error-handling. The following table provides guidance on how to deal with\ 
>		waiting for tasks in a non-blocking way:

> Example: Retrieving the Result of a Background Task
> 
> | blocking code 							           | non-blocking code 	 	  							     | when to use `await` 		   			      |
> | -------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------ |
> | `var result = myTask.Result;` 			           | `var result = await myTask;` 							 | Retrieving the result of a background task |
> | `int index = Task.WaitAny(task1, task2);`      	   | `var completedTask = await Task.WhenAny(task1, task2);` | Waiting for Any Task to Complete 		  |
> | `Task.WaitAll(task1, task2, task3);` 		       | `await Task.WhenAll(task1, task2, task3);` 			 | Waiting for All Tasks to Complete 		  |
> | `Thread.Sleep(2000); // Blocks the current thread` | `await Task.Delay(2000); // Non-blocking wait`          | Waiting for a Period of Time 			  |


Consider using ValueTask where possible

Returning a Task object from async methods can introduce performance bottlenecks in certain paths. Task is a reference type, so using it means allocating an object. In cases where a method declared with the async modifier returns a cached result or completes synchronously, the extra allocations can become a significant time cost in performance critical sections of code. It can become costly if those allocations occur in tight loops. For more information, see generalized async return types.

Consider using ConfigureAwait(false)

A common question is, "when should I use the Task.ConfigureAwait(Boolean) method?". The method allows for a Task instance to configure its awaiter. This is an important consideration and setting it incorrectly could potentially have performance implications and even deadlocks. For more information on ConfigureAwait, see the ConfigureAwait FAQ.

Write less stateful code

Don't depend on the state of global objects or the execution of certain methods. Instead, depend only on the return values of methods. Why?

Code will be easier to reason about.
Code will be easier to test.
Mixing async and synchronous code is far simpler.
Race conditions can typically be avoided altogether.
Depending on return values makes coordinating async code simple.
(Bonus) it works really well with dependency injection.