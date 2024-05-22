#define SENSOR_PIN 0
#define TERM 100
#define LOW_READ_VALUE 180
#define HIGH_READ_VALUE 200
#define LOW_OUT_VALUE 0
#define HIGH_OUT_VALUE 10
int index = 0;
int values[TERM];

void setup() {
  Serial.begin(9600);
}

// 100回取得してその最頻値を出力する
void loop() {
  if (index < TERM) {
    int read_val = analogRead(SENSOR_PIN);
    int out_val = map(read_val, LOW_READ_VALUE, HIGH_READ_VALUE, LOW_OUT_VALUE, HIGH_OUT_VALUE);

    if (out_val <= 0) {
      out_val = 0;
    } else if (10 <= out_val) {
      out_val = 10;
    }

    values[index] = out_val;
    index++;
  } else {
    int print_val = modeVal(values);
    Serial.println(print_val);
    index = 0;
  }
}

// 最頻値を返す関数
int modeVal(int values[TERM]) {
  int mode[TERM] = {};
  for (int i = 0; i < TERM; i++) {
    mode[values[i]]++;
  }
  int m = 0;
  int ret = 0;
  for (int i = 0; i < TERM; i++) {
    if (mode[i] > m) {
      m = mode[i];
      ret = i;
    }
  }
  return ret;
}
