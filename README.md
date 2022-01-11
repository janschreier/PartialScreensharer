# PartialScreensharer

Have your colleagues complained not being able to see what you shared with them, because your screen is ultra-wide while theirs is smaller? 
Have you whished to share only a part of the screen? 

Usage:
1. Start PartialScreensharer
2. Position to the area you want others to be able to see
3. Share the App's window
4. Move the stuff you want to share over that window and your colleagues will see it.
5. To stop the app, close the app, either by using the button or by rightclicking in the taskbar.

Internally the program creates screenshots of the area where the app is placed every 200 milliseconds and displays this screenshot within the app itself.

It's not pretty but it does the job :)


Inspired by [this comment](https://github.com/microsoft/PowerToys/issues/2774#issuecomment-993953197) I decided to create a program in WPF that does just that.