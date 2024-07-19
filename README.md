# Partial Screensharer

Have your colleagues complained not being able to see what you shared with them, because your screen is ultra-wide while theirs is smaller? 
Have you whished to share only a part of the screen? 

## Requirements
* Build with .net 8 and thus requires the respective .net runtime

## Usage with Teams:
1. Start Partial Screensharer
2. Position to the area you want others to be able to see
3. Share the App's window
4. Move the stuff you want to share over that window and your colleagues will see it.
5. To stop the app, close the app, either by using the button or by rightclicking in the taskbar.

## Usage with Skype (experimental):
1. Start Partial Screensharer
2. Position to the area you want others to be able to see
3. Click "Set Area"
4. Move the window to an area on your screen that will be visible to yourself during the entire screen sharing session 
(otherwise no one will see anything as Skype only displays that part of the window you can see yourself wheras Teams shows 
the windows content)
5. Share the App's window
6. Move the stuff you want to share over that window and your colleagues will see it.
7. To stop the app, close the app, either by using the button or by rightclicking in the taskbar. 


## Download
For those seeking for an .exe-File I put one up on my server. [Download it here](https://janschreier.de/PartialScreensharer.zip) or compile the above sourcecode

## Background Info

Internally the program creates screenshots of the area where the app is placed every 200 milliseconds and displays this screenshot within the app itself.

It's not pretty but it does the job :)


Inspired by [this comment](https://github.com/microsoft/PowerToys/issues/2774#issuecomment-993953197) I decided to create a program in WPF that does just that.