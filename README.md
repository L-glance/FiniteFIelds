# Библиотека для работы с конечными полями
> Все поля подразумеваются конечными.
# Основные типы

## Конечное поле
Примеры создание полей $F_{3}$ и $F_{2^2}$
```c#
//Создание простого поля
FiniteField GF3 = new FiniteField(3);

//Создание расширенного поля
int[] irreduciblePolynomial = new int[] {1,1,1};
int characteristic = 2;
int degree = 2;
FiniteField GF4 = new FiniteField(characteristic, degree, new int[] { 1, 1, 1 }); 
```
## Элемент поля
```c#
```
