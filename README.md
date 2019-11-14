# ConcurrentTasks
How to run async tasks concurrently in C#

Application output
```
Executes each async request in order
Starting All Awaits Tests
TaskOne Complete
TaskTwo Complete
TaskThree Complete
TaskFour Complete
TaskFive Complete
All Awaits Test Completed: 5128

Executes each async request concurrently
Starting Task When All Tests
TaskOne Complete
TaskTwo Complete
TaskThree Complete
TaskFive Complete
TaskFour Complete
Task When All Test Completed: 1990

Executes each async request concurrently but doesn't wait for them to finish before continuing
Starting Parallel Tasks Tests
TaskThree Complete
TaskOne Complete
TaskFour Complete
TaskTwo Complete
Task Parallel Tasks Test Completed: 1031

```
