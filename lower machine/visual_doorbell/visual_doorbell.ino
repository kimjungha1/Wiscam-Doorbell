
#include <LiquidCrystal.h>
LiquidCrystal lcd(8, 9, 10, 11, 12, 13);
const int analogOutPin = 3; //  模拟输出引脚
int flase = 0;
int x = 9;
int outputValue = 0;
char rec[7];
const int numR = 2;//定义3行
const int numC = 2;//定义3列
const int debounceTime = 20;//去抖动时间长度
const char keymap[numR][numC]= {

  { '2','3' },

  {'5','6',},
};
const int rowPins[numR] = {4,5};//设置硬件对应的引脚
const int colPins[numC] = {6,7};
//初始化功能
void setup(){
Serial.begin(115200);
 lcd.begin(16, 2);
  // 打印字符串
  lcd.print("hello,WisCam!");
   lcd.setCursor(0,1);
   lcd.print("room num:");
   lcd.blink();
for(int row = 0; row < numR; row++){
   pinMode(rowPins[row],INPUT);
   digitalWrite(rowPins[row],HIGH);

}
for(int column = 0;column < numC; column++){
    pinMode(colPins[column],OUTPUT);
    digitalWrite(colPins[column],HIGH);
 }
}
//主循环
void loop() {
      char key = getkey();
      if(key !=0){
      //Serial.println(key);
       lcd.setCursor(x,1);
       //lcd.blink();
       lcd.print(key);
      Serial.write(key);
      x++;
      if(x==13)x=9;
      }
      if (Serial.available() > 0)
  {
    flase = 1;
    for (int i = 0; i < 7; i++)
    {
      rec[i] = Serial.read();
      Serial.print(rec[i] ); // 打印结果到串口监视器

    }
    // 读取模拟量值Pin);
    outputValue = rec[5];
  }
  analogWrite(analogOutPin, outputValue);
  delay(20);
}

//读取键值程序
char getkey(){
    char key = 0;
    for(int column = 0;column < numC; column++){
      digitalWrite(colPins[column],LOW);
      for(int row = 0 ;row < numR; row++){
        if(digitalRead(rowPins[row]) == LOW){ //是否有按键按下
          delay(debounceTime);
          while(digitalRead(rowPins[row]) == LOW)  //等待按键释放
            ;
          key = keymap[row][column];   
        }
      }
      digitalWrite(colPins[column],HIGH); //De-active the current column
    }
    return key;
  }

