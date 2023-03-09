# Библиотека для работы с конечными полями
Реализованы операции сложения, вычитания, умножения, деления, получение обратного и противоположного.
Для поля характеристики 2 реализована конвертация элементов поля в массив байтов и конвертация байтов в элементы поля.
> Все поля подразумеваются конечными.
# 1. Простое поле
## 1.1 Cоздание поля
```c#
//Создание простого поля
  FiniteField GF3 = new FiniteField(3);
```
## 1.2 Методы поля
### Получение Единичного элемента
```c#
  var GF11 = new FiniteField(11);
  FiniteFieldElement identity = GF11.GetOne();
```
### Получение нуля
```c#
  var GF11 = new FiniteField(11);
  FiniteFieldElement zero = GF11.GetZero();
```
## 1.3 Создание Элемента 
```c#
//Создание элемента простого поля
  var GF11 = new FiniteField(11);
  FiniteFieldElement element = new FinitiFieldElement(4,GF11);
```
## 1.4 Операции над элементами
### Сложение
```c#
  var GF11 = new FiniteField(11);
  FiniteFieldElement a = new FiniteFieldElement(4, GF11); // 4
  FiniteFieldElement b = new FiniteFieldElement(5, GF11); // 5
  FiniteFieldElement c = a + b; // 9
```
### Вычитание
```c#
var GF11 = new FiniteField(11);
  FiniteFieldElement a = new FiniteFieldElement(3, GF11); // 3
  FiniteFieldElement b = new FiniteFieldElement(5, GF11); // 5
  FiniteFieldElement c = a - b; // 9
```
### Умножение
```c#
  var GF11 = new FiniteField(11);
  FiniteFieldElement a = new FiniteFieldElement(3, GF11); // 3
  FiniteFieldElement b = new FiniteFieldElement(5, GF11); // 5
  FiniteFieldElement c = a * b; // 4 
```
### Возведение в степень
```c#
  var GF11 = new FiniteField(11);
  FiniteFieldElement a = new FiniteFieldElement(3, GF11); // 3
  FiniteFieldElement aExtent = a.Pow(3); // 5
```
### Деление
```c#
  var GF11 = new FiniteField(11);
  FiniteFieldElement a = new FiniteFieldElement(3, GF11); // 3
  FiniteFieldElement b = new FiniteFieldElement(5, GF11); // 5
  FiniteFieldElement divided = a / b; // 5
```
### Нахождение обратного по умножению
```c#
  var GF11 = new FiniteField(11);
  FiniteFieldElement a = new FiniteFieldElement(3, GF11); // 3
  FiniteFieldElement inv = a.GetInverse(); // 4
```
### Нахождение обратного по сложению
```c#
  var GF11 = new FiniteField(11);
  FiniteFieldElement a = new FiniteFieldElement(3, GF11); // 3
  FiniteFieldElement inv2 = a.GetOpposite(); // 8
```

# 2. Расширенное поле
```c#
//Создание расширенного поля
  int[] irreduciblePolynomial = new int[] {1,1,1};
  int characteristic = 2;
  int degree = 2;
  FiniteField GF4 = new FiniteField(characteristic, degree, new int[] { 1, 1, 1 }); 
```
## 2.1 Создание элемента
```c#
//создание элемента расширенного поля
  var GF9 = new FiniteField(3,2,new int[]{1,1,2});
  FiniteFieldElement element = new FiniteFieldElement(new int[]{2,1},GF9)
```
## 2.2 Операции над элементами
### Сложение
```c#
  var GF32 = new FiniteField(2, 5, new int[] { 1, 0, 0, 1, 0, 1 });
  FiniteFieldElement a = new FiniteFieldElement(new int[] {1,1,1,1},GF32); // x^3+x^2+x+1 ~ 15
  FiniteFieldElement b = new FiniteFieldElement(new int[] {1,0,0,0,0},GF32); // x^4 ~ 16
  FiniteFieldElement c = a + b; // x^4 + x^3 + x^2 + x +1 ~ 31
```
### Вычитание
```c#
  var GF32 = new FiniteField(2, 5, new int[] { 1, 0, 0, 1, 0, 1 });
  FiniteFieldElement a = new FiniteFieldElement(new int[] {1,1,1,1},GF32); // x^3+x^2+x+1 ~ 15
  FiniteFieldElement b = new FiniteFieldElement(new int[] {1,0,0,0,0},GF32); // x^4 ~ 16
  FiniteFieldElement c = a - b; // x^4 + x^3 + x^2 + x +1 ~ 31
```
### Умножение
```c#
  var GF32 = new FiniteField(2, 5, new int[] { 1, 0, 0, 1, 0, 1 });
  FiniteFieldElement a = new FiniteFieldElement(new int[] {1,1,1,1},GF32); // x^3+x^2+x+1 ~ 15
  FiniteFieldElement b = new FiniteFieldElement(new int[] {1,0,0,0,0},GF32); // x^4 ~ 16
  FiniteFieldElement c = a * b; // x^3 + x + 1 ~ 11
```
### Возведение в степень
```c#
  var GF32 = new FiniteField(2, 5, new int[] { 1, 0, 0, 1, 0, 1 });
  FiniteFieldElement a = new FiniteFieldElement(new int[] {1,1,1,1},GF32); // x^3+x^2+x+1 ~ 15
  FiniteFieldElement aExtent = a.Pow(3); // x^4 + x^2 ~ 20
```
### Деление
```c#
  var GF32 = new FiniteField(2, 5, new int[] { 1, 0, 0, 1, 0, 1 });
  FiniteFieldElement a = new FiniteFieldElement(new int[] {1,1,1,1},GF32); // x^3+x^2+x+1 ~ 15
  FiniteFieldElement b = new FiniteFieldElement(new int[] { 1, 0, 0, 0, 0 }, GF32); // x^4 ~ 16
  FiniteFieldElement divided = a / b; // x^2 + x ~ 6
```
### Нахождение обратного по умножению
```c#
  var GF32 = new FiniteField(2, 5, new int[] { 1, 0, 0, 1, 0, 1 });
  FiniteFieldElement a = new FiniteFieldElement(new int[] { 1, 0, 0, 0, 0 }, GF32); // x^4 ~ 16
  FiniteFieldElement inv = a.GetInverse(); // x^3 + x + 1 ~ 11
```
### Нахождение обратного по сложению
```c#
  var GF32 = new FiniteField(2, 5, new int[] { 1, 0, 0, 1, 0, 1 });
  FiniteFieldElement a = new FiniteFieldElement(new int[] { 1, 0, 0, 0, 0 }, GF32); // x^4 ~ 16
  FiniteFieldElement inv = a.GetOpposite(); // x^4 ~ 16
```
# 3 Дополнительные операции
Если поле имеет характеристики 2, возможна конвертация элементов поля в байты
```c#
  var GF2 = new FiniteField(2);
  FiniteFieldElement a = new FiniteFieldElement(1);
  byte[] byteArray = a.ConvertToByte();
```
А также Конвертация байтов в элементы поля
```c#
  var GF32 = new FiniteField(2,5,new int[] {1,0,0,1,0,1});;
  FiniteFieldElement a = new FiniteFieldElement(1);
  byte[] byteArray = new byte[] { 31, 0, 0, 0}
  FiniteFieldElement a = GF32.GetFiniteFieldElement(byteArray); // x^4+x^3+x^2+x+1 ~ 31
```
