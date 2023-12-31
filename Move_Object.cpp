
@opentechhd
@opentechhd
8 months ago
SOURCE CODE (COPY & PASTE):
// Controll Motion of a Circle(Player)
// Copied From YT Video
// 03 JAN 2023, 03:11 PM
#include <graphics.h>

int main() {
	initwindow(900,600);					// size of the graphics window (width, height)
	
	int x=300, y=300;						// initial postion of the circle (is center)

	while(1) {								// while(1) & while(true) have same meaning, it continuously perfoms the foll. actions

		cleardevice();						// clear the screen, here it clear every last postion of the circle
		
		setcolor(GREEN);
		circle(x,y,10);						// circle having x & y position & also radius of 10
		circle(x,y,11);
		
		if(GetAsyncKeyState(VK_RIGHT))		// move circle to righ side when press RIGHT ARROW KEY
			x+=2;
		else
		if(GetAsyncKeyState(VK_LEFT))		// move circle to left side when press LEFT ARROW KEY
			x-=2;
		else
		if(GetAsyncKeyState(VK_UP))			// move circle upward (forward) when press UP ARROW KEY
			y-=2;
		else
		if(GetAsyncKeyState(VK_DOWN))		// move circle downward (back) when press DOWN ARROW KEY
			y+=2;
		
		if(GetAsyncKeyState(VK_RETURN))		// exit game when press ENTER KEY
			break;
		
		delay(10);							// wait b/w key press & motion (in milli seconds), smooth motion
		
	}
	
	getch();
	return 0;
}