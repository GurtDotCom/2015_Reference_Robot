

#define X_STEP_PIN 54
#define X_DIR_PIN 55
#define X_ENABLE_PIN 38
#define X_MIN_PIN 2

#define Y_STEP_PIN 60
#define Y_DIR_PIN 61
#define Y_ENABLE_PIN 56
#define Y_MIN_PIN 3

#define FAN_PIN 9

int fricken_laser = 53;
unsigned long lastFan;
int curPan, curTilt, panDiff, tiltDiff = 0;
unsigned long lastFire;
int seekPos;
boolean moveLeft, moveDown = true;
        int pan = 0;
        int tilt = 0;
        int laser_on = 0;

// for printf
int my_putc(char c, FILE *t)
{
    Serial.write(c);
}

void setup()
{
    fdevopen(&my_putc, 0);  
    Serial.begin(57600);
    Serial.setTimeout(1000);
    pinMode(fricken_laser, OUTPUT);
    digitalWrite(fricken_laser, HIGH);
    
pinMode(X_STEP_PIN , OUTPUT);
pinMode(X_DIR_PIN , OUTPUT);
pinMode(X_ENABLE_PIN , OUTPUT);
pinMode(X_MIN_PIN , INPUT);

pinMode(Y_STEP_PIN , OUTPUT);
pinMode(Y_DIR_PIN , OUTPUT);
pinMode(Y_ENABLE_PIN , OUTPUT);
pinMode(Y_MIN_PIN , INPUT);

pinMode(FAN_PIN , OUTPUT);

digitalWrite(X_ENABLE_PIN , LOW);
digitalWrite(Y_ENABLE_PIN , LOW);

lastFan = millis();
digitalWrite(FAN_PIN , HIGH);
SlowZeroize();

}

void loop()
{


  if (millis() > (lastFan + 15000)){
  digitalWrite(FAN_PIN , LOW);
  }
  if (millis() > (lastFan + 20000)){
  lastFan = millis();  
  digitalWrite(FAN_PIN , HIGH);
  }
  
  
       if((millis() - lastFire) >= 1000){
        digitalWrite(fricken_laser, HIGH);
        } 
    char buf[10];
    int num_read = 0;
    memset(buf,0,sizeof(buf));
    num_read = Serial.readBytesUntil('\n',buf,10);
    if (num_read == 10)
    {

        if (buf[0] == 'S'){
         //begin hunt mode 
         Hunt();
        } else if (buf[0] == 'H'){
        GoHome();
        } else if (buf[0] == 'Z'){
          SlowZeroize();
        } else if (buf[0] == 'F'){
          FastZeroize();
        } else {
        sscanf(buf,"%d,%d,%d\n",&pan,&tilt,&laser_on);
        Move();       
        }
        
} 
printf("updated");
}

void SlowZeroize(){
  
  seekPos = 1;
digitalWrite(X_DIR_PIN , LOW);  
digitalWrite(Y_DIR_PIN , HIGH);
moveLeft = true;
moveDown = true;
  
for (int run = 0; run < 50; run++) {
digitalWrite(X_STEP_PIN , LOW);
digitalWrite(X_STEP_PIN , HIGH);
digitalWrite(Y_STEP_PIN , LOW);
digitalWrite(Y_STEP_PIN , HIGH);
delay(3);  

      }
  
      
digitalWrite(X_DIR_PIN , HIGH);  
digitalWrite(Y_DIR_PIN , LOW);
moveLeft = false;
moveDown = false;

while (digitalRead(Y_MIN_PIN) == LOW ) {
digitalWrite(Y_STEP_PIN , LOW);
digitalWrite(Y_STEP_PIN , HIGH);
delay(8);
} 

  while (digitalRead(X_MIN_PIN) == LOW ) {
digitalWrite(X_STEP_PIN , LOW);
digitalWrite(X_STEP_PIN , HIGH);
delay(8);  

} 

digitalWrite(X_DIR_PIN , LOW);  
digitalWrite(Y_DIR_PIN , HIGH);
moveLeft = true;
moveDown = true;


for (int run = 0; run < 100; run++) {
digitalWrite(X_STEP_PIN , LOW);
digitalWrite(X_STEP_PIN , HIGH);
digitalWrite(Y_STEP_PIN , LOW);
digitalWrite(Y_STEP_PIN , HIGH);
delay(2);
//delayMicroseconds(700);
//__asm__("nop\n\t"); 
      }
      
      
for (int run = 0; run < 250; run++) {
digitalWrite(X_STEP_PIN , LOW);
digitalWrite(X_STEP_PIN , HIGH);
delay(2);
//delayMicroseconds(11500);
//__asm__("nop\n\t"); 

}
curPan = 350;
curTilt = 100;
      
      
 
  
}

void Hunt(){

if (moveLeft) {
     if (curPan + 20 > 600) {
      digitalWrite(X_DIR_PIN , HIGH); 
      moveLeft = false;
      curPan = curPan - 20;
     }  
  } else {
     if (curPan - 20 < 0) {
      digitalWrite(X_DIR_PIN , LOW); 
      moveLeft = true; 
      curPan = curPan + 20;
      }
  }
  

      for (int run = 0; run < 20; run++) {
      digitalWrite(X_STEP_PIN , LOW);
      digitalWrite(X_STEP_PIN , HIGH);
      delay(1);
      }
  
//curPan = 350;
//curTilt = 200;
  
}



void Move(){
  if (pan < 0){
digitalWrite(X_DIR_PIN , HIGH);  
//panDiff = curPan - pan;
panDiff = 0 - pan;
moveLeft = false;
} 
if (pan > 0){
digitalWrite(X_DIR_PIN , LOW); 
//panDiff = curPan + pan;
panDiff = pan;
moveLeft = true;
}

if (pan == 0){
  panDiff = panDiff;
}


if (tilt < 0){
digitalWrite(Y_DIR_PIN , LOW); 
//tiltDiff = curTilt - tilt;
tiltDiff = 0 - tilt;
moveDown = false;

} 
if (tilt > 0){
digitalWrite(Y_DIR_PIN , HIGH);  
//tiltDiff = curTilt + tilt;
tiltDiff = tilt;
moveDown = true;
}  
if (tilt == 0){
  tiltDiff = tiltDiff;
}


while ((panDiff != 0) && (tiltDiff !=0)){
if((moveLeft) && ((curPan + 1) <= 500)){
digitalWrite(X_STEP_PIN , LOW);
digitalWrite(X_STEP_PIN , HIGH);
curPan = curPan + 1;
}
if((!moveLeft) && ((curPan - 1) >= 200)){
digitalWrite(X_STEP_PIN , LOW);
digitalWrite(X_STEP_PIN , HIGH);
curPan = curPan - 1;
}


if((moveDown) && ((curTilt + 1) <= 175)){
digitalWrite(Y_STEP_PIN , LOW);
digitalWrite(Y_STEP_PIN , HIGH);
curTilt = curTilt + 1;
}
if((!moveDown) && ((curTilt - 1) >= 50)){
digitalWrite(Y_STEP_PIN , LOW);
digitalWrite(Y_STEP_PIN , HIGH);
curTilt = curTilt - 1;
}  
tiltDiff -= 1;


panDiff -= 1;

delay(1);  
//delayMicroseconds(999);
//__asm__("nop\n\t"); 
}

if (panDiff != 0){
for (int run = 0; run < panDiff; run++) {
if((moveLeft) && ((curPan + 1) <= 500)){
digitalWrite(X_STEP_PIN , LOW);
digitalWrite(X_STEP_PIN , HIGH);
curPan = curPan + 1;
}
if((!moveLeft) && ((curPan - 1) >= 200)){
digitalWrite(X_STEP_PIN , LOW);
digitalWrite(X_STEP_PIN , HIGH);
curPan = curPan - 1;
}
panDiff -= 1;
delay(1);  
//delayMicroseconds(999);
//__asm__("nop\n\t"); 
      }
}

if (tiltDiff != 0){
for (int run = 0; run < tiltDiff; run++) {
if((moveDown) && ((curTilt + 1) <= 175)){
digitalWrite(Y_STEP_PIN , LOW);
digitalWrite(Y_STEP_PIN , HIGH);
curTilt = curTilt + 1;
}


if((!moveDown) && ((curTilt - 1) >= 50)){
digitalWrite(Y_STEP_PIN , LOW);
digitalWrite(Y_STEP_PIN , HIGH);
curTilt = curTilt - 1;
} 




tiltDiff -= 1;
delay(1);  
//delayMicroseconds(999);
//__asm__("nop\n\t"); 
      }
}
        

        
        
        
        
        if ((laser_on) && ((millis()-lastFire) >= 2000)){
        digitalWrite(fricken_laser, LOW);
        lastFire = millis();    
        }
    
    
        printf("updated");
       // curPan = curPan + panDiff;
       // curTilt = curTilt + tiltDiff;
   
    
       if((millis() - lastFire) >= 1000){
        digitalWrite(fricken_laser, HIGH);
        } 


    
}

// samples datas
// 100,100,1

// 150,100,0


void GoHome(){

      pan = 350 - curPan;  
      tilt = 100 - curTilt;

      
      Move(); 
  
}


void FastZeroize(){
 
  
seekPos = 1;
digitalWrite(X_DIR_PIN , LOW);  
digitalWrite(Y_DIR_PIN , HIGH);
moveLeft = true;
moveDown = true;
  
for (int run = 0; run < 50; run++) {
digitalWrite(X_STEP_PIN , LOW);
digitalWrite(X_STEP_PIN , HIGH);
digitalWrite(Y_STEP_PIN , LOW);
digitalWrite(Y_STEP_PIN , HIGH);
delayMicroseconds(999); 

      }
  
      
digitalWrite(X_DIR_PIN , HIGH);  
digitalWrite(Y_DIR_PIN , LOW);
moveLeft = false;
moveDown = false;

while (digitalRead(Y_MIN_PIN) == LOW ) {
digitalWrite(Y_STEP_PIN , LOW);
digitalWrite(Y_STEP_PIN , HIGH);
delay(1);
} 

  while (digitalRead(X_MIN_PIN) == LOW ) {
digitalWrite(X_STEP_PIN , LOW);
digitalWrite(X_STEP_PIN , HIGH);
delay(1);  

} 

digitalWrite(X_DIR_PIN , LOW);  
digitalWrite(Y_DIR_PIN , HIGH);
moveLeft = true;
moveDown = true;


for (int run = 0; run < 100; run++) {
digitalWrite(X_STEP_PIN , LOW);
digitalWrite(X_STEP_PIN , HIGH);
digitalWrite(Y_STEP_PIN , LOW);
digitalWrite(Y_STEP_PIN , HIGH);
//delay(1);
delayMicroseconds(999);
//__asm__("nop\n\t"); 
      }
      
      
for (int run = 0; run < 250; run++) {
digitalWrite(X_STEP_PIN , LOW);
digitalWrite(X_STEP_PIN , HIGH);
//delay(1);
delayMicroseconds(999);
//__asm__("nop\n\t"); 

}
curPan = 350;
curTilt = 100;
      
  
}


