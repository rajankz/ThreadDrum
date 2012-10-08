int val0 = 0;
int val1 = 0;
int val2 = 0;
int val3 = 0;

void setup(){
  Serial.begin(9600);
}

void loop(){
  val0 = analogRead(A0);
  val1 = analogRead(A1);
  val2 = analogRead(A2);
  val3 = analogRead(A3);
  if(val0 > 500){
    Serial.println("0: "+String(val0,DEC));
    delay(100);
  }
  if(val1 > 500){
    Serial.println("1: "+String(val1,DEC));
    delay(100);
  }
  if(val2 > 500){
    Serial.println("2: "+String(val2,DEC));
    delay(100);
  }
  if(val3 > 500){
    Serial.println("3: "+String(val3, DEC));
    delay(100);
  }
}
