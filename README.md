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
All Awaits Test Completed: 5133

Executes each async request concurrently
Starting Task When All Tests
TaskOne Complete
TaskThree Complete
TaskTwo Complete
TaskFive Complete
TaskFour Complete
Task When All Test Completed: 1995

Executes each async request concurrently but doesn't wait for them to finish before continuing
Starting Parallel Tasks Tests
TaskFive Complete
TaskFour Complete
TaskThree Complete
TaskTwo Complete
Task Parallel Tasks Test Completed: 1026
TaskOne Complete

```
