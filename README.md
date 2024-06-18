# **Логическая игра "Гомоку"**

Реализация логической игры "Гомоку" в рамках курсового проекта по дисциплине «Проектная и научно-исследовательская деятельность».

# **Функции**

* Удобная и предельно понятная для пользователя функциональность

* Возможность игры с компьютером выбранной сложности

* Возможность игры с другом

* Возможности подсказки и отмены хода

* Возможность изучить правила игры и ключевые ходы

* Возможность сохранения последней активности пользователя и ведения статистики

* Современный, приятный пользовательский интерфейс

# **О программе**

* Интерфейс программы

<img src="https://github.com/11qfour/Gomoku-game/blob/main/Gomoku/image1/Interface.jpg" border="0">

![Игровой процесс](https://github.com/11qfour/Gomoku-game/blob/main/Gomoku/image1/Game.gif)
# **Используемые алгоритмы в реализации игры с компьютером**

* Улучшенный алгоритм простого поиска (используется окрестность Мура клетки игрового поля последнего хода) - легкий уровень Бота

Инициализируем координаты клеток из окрестности Мура:
  1) Moore[0, 0] = i - 1; Moore[0, 1] = j + 1;
  2) Moore[1, 0] = i; Moore[1, 1] = j + 1;
  3) Moore[2, 0] = i + 1; Moore[2, 1] = j + 1;
  4) Moore[3, 0] = i - 1; Moore[3, 1] = j;
  5) Moore[4, 0] = i + 1; Moore[4, 1] = j;
  6) Moore[5, 0] = i - 1; Moore[5, 1] = j - 1;
  7) Moore[6, 0] = i; Moore[6, 1] = j - 1;
  8) Moore[7, 0] = i + 1; Moore[7, 1] = j - 1;
Получим восемь значений, из которых после выберем любую свободную клетку используя объект класса Random. 
Если же таких клеток не будет, то выберем любую свободную клетку игрового поля.

* Эвристический алгоритм - средний уровень Бота

Алгоритм направлен на возврат наибольшего значения, соответствующего заданному шаблону, благодаря которому возможно одержать победу. Потому на поиск хода требуется немного времени.
Символ currValue или C – значение цвета, за который играет Бот, oppValue или O – значение Пользователя, E-пустая клетка.
1. Паттерны для нападения:
  1)	открытые и закрытые четверки ECCCCE, ECCCCO и OCCCCE – вернуть 100000000;
  2)	открытая тройка ECCCE – вернуть 99999999;
  3)	закрытые тройки ECCCO и OCCCE – вернуть 4000000;
  4)	открытая двойка ECCE – вернуть 500;
  5)	оакрытые двойка ECCO и OCCE – вернуть 50;
  6)	одиночка ECE, ECO и OCE – вернуть 25;
2. Паттерны для укрепления защиты:
  1)	открытые и закрытые четверки EOOOOE, EOOOOC и COOOOE – вернуть -100000000;
  2)	открытая тройка EOOOE – вернуть -99999999;
  3)	закрытые тройки EOOOC и COOOE – вернуть -4000000;
  4)	открытая двойка EOOE – вернуть -500;
  5)	закрытые двойка EOOC и COOE – вернуть -50;
  6)	одиночка EOE, EOC и COE - вернуть -25;
Таким образом, алгоритм возвращает хорошее, но не всегда оптимальное значение ответного хода компьютера, но за небольшое по сравнению с точными алгоритмами время.

# **[Скачать](https://github.com/11qfour/Gomoku-game/blob/main/Gomoku/Gomoku/bin/Debug/Gomoku.exe)**