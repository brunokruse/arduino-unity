/*

  ARDUINO to UNITY3D Smooth data example

  Based off Arduino smoothing code by:
  David A. Mellis and Tom Igoe 
  
  This example code is in the public domain.
  
*/

const int numReadings = 5;      // Define the number of samples to keep track of.
int inputPin = A0;              // The port your sensor is connected to

int readings[numReadings];      // the readings from the analog input
int readIndex = 0;              // the index of the current reading
int total = 0;                  // the running total
int average = 0;                // the average

void setup() {
  // initialize serial communication
  Serial.begin(9600);
  
  // initialize all the readings to 0
  for (int thisReading = 0; thisReading < numReadings; thisReading++)
    readings[thisReading] = 0;
    
}

void loop() {
  // calculate average
  total = total - readings[readIndex];
  readings[readIndex] = analogRead(inputPin);
  total = total + readings[readIndex];
  readIndex = readIndex + 1;
  
  if (readIndex >= numReadings) {
    readIndex = 0;
  }

  average = total / numReadings; // average
  
  Serial.println(average); // whatever is printed here is sent to UNITY
  delay(20); // delay in between reads for stability
  
}



