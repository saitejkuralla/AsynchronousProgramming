## Asynchronous Programming Patterns :rocket:
Asynchronous programming techniques or patterns are commonly used to handle long-running or potentially blocking operations. These patterns are designed to improve application performance, resource utilization, and scalability by allowing multiple operations to run concurrently and by freeing up resources while waiting for an operation to complete.

### Fire and Forget :fire:
* A programming pattern in which a method or function is executed asynchronously without waiting for the completion of the task.
* :sparkles: This pattern is typically used in scenarios where the result of the operation is not needed, and the primary goal is to avoid blocking the calling thread. :sparkles:
* Once the asynchronous task is started, the application proceeds with other operations without waiting for the task to complete.

### OnFailure :x:
* It is an extension method that can be used with Task objects in C#. It allows you to specify an action that will be executed if the task fails due to an exception.
* :sparkles: OnFailure is particularly useful when you have a long-running task that is likely to fail at some point. :sparkles:
* This method takes an action as a parameter, which is executed if the task fails.
* This action is passed to the exception that caused the task to fail, and can be used to log the error, notify the user, or take other appropriate action.

### Timeout :hourglass_flowing_sand:
* :sparkles: Timeout is a mechanism to limit the amount of time a particular operation can take to complete. :sparkles:
* This can be achieved using the Task.WhenAny method to wait for the first task to complete, and then checking if it was the expected task.
* If not, it means that the timeout has occurred, and the operation should be cancelled.

### Retry :repeat:
* This method takes the maximum number of retries and the delay between each retry as parameters.
* :sparkles: Retry can be useful when dealing with unreliable or slow external services, where retrying the operation can improve the success rate of the overall process. :sparkles:
* It attempts to execute a Func<Task<TResult>> delegate, which represents an asynchronous operation, a certain number of times in case of failures.

### Fallback :leftwards_arrow_with_hook:
* This technique is used in software development to provide a secondary or alternative option in case the primary option fails or becomes unavailable.
* :sparkles: Fallback can be useful when dealing with external services, where it is important to have a backup plan in case the primary service is not available. :sparkles:
