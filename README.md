# MouseClicker

.NET 7.0 windows form application that allows to record desktop mouse clicks as macros, save such macros to file, and play them in loop.

![MouseClickerGuide](https://github.com/GiovanniCastellano/MouseClicker/assets/58817731/bc3ee016-2692-434a-8353-6c9fec9a224a)

1) Start executing loaded macro.
2) Stop execution.
3) Check what points the macro is going to click and what delay there is between them. Points are clicked in order, and the delay refers to the time that passes between a click on the previous point and the current one. The delay for the first point refers to the time waited before clicking that point after macro execution starts.
4) Enter recording state: every mouse click will be recorded while in this state. After exiting the recording state, user is prompted with a save dialog requesting a file name for the new macro.
5) Load a previously recorded macro from file.
6) Useful information about user interactions
