#include <SoftwareSerial.h>
#include "Servo.h"
Servo myservoindex;
Servo myservomiddle;
Servo myservothumb;
int blueTx=11;
int blueRx=12; 
SoftwareSerial mySerial(blueTx, blueRx);
String myString="";
void setup() {
  myservoindex.attach(3); 
  myservomiddle.attach(5); 
  myservothumb.attach(6); 
  myservoindex.write(60);  
  myservomiddle.write(60);
  myservothumb.write(17 0);
  mySerial.begin(9600);
}
void loop() {
  while(mySerial.available())
  {
    char myChar = (char)mySerial.read();
    myString+=myChar;
    delay(5);
  }
  if(!myString.equals(""))
  {
    Serial.println("input value: "+myString);
      if(myString=="a")
      {
        myservoindex.write(1);
        delay(5);
      } 
      if(myString=="b")
      {
        myservoindex.write(100);
        delay(5);
      }
      if(myString=="c")
      {
        myservomiddle.write(30);
        delay(5);
      }
      if(myString=="d")
      {
        myservomiddle.write(85);
        delay(5);
      }
      if(myString=="e")
      {
        myservothumb.write(65);
        delay(5);
      }
      if(myString=="f")
      {
        myservothumb.write(180);
        delay(5);
      }
      if(myString=="g")
      {
        myservoindex.write(1);
        myservomiddle.write(30);
        myservothumb.write(65);
        delay(5);
      }
      if(myString=="h")
      {
        myservoindex.write(100);
        myservomiddle.write(85);
        myservothumb.write(180);
        delay(5); 
      }
    myString=""; 
  }
}
