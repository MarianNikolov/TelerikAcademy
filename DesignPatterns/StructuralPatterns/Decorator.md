# Decorator
### Structural Design Pattern

## Обобщение
Decorator Pattern-ът идеята е да може да се добавя допълнителна функционалност по време на работа на приложението (runtime). Спазва open/close принципа.
Този pattern е подходящ е екстендване на стар код, на който е трудно да се добави нова функционалност.
Пример за декоратор е sream, на който чрез декорратор може да му се добави нова функционалност, като CryptoStream или GZipStream, които съответно позвлява освен стрийма и криптиране или архивиране.