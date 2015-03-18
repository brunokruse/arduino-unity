int inData = 1;
int ledPin = 2;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);
  
}

void loop() {
  // put your main code here, to run repeatedly:
  
  if (Serial.available()) {  
    inData = Serial.read();
    
    if (inData == '0') {
      // turn on
      digitalWrite(ledPin, HIGH);
      
    } else if (inData == '1') {
      // turn off
      digitalWrite(ledPin, LOW);
      
    }
  }

}
