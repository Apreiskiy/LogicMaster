# Logic Master
----RU----
Logic Master — desktop-приложение на C# для анализа, синтеза и минимизации логических функций

Программа позволяет вводить логические выражения, строить таблицы истинности, получать ДСНФ/КСНФ, представлять функции в различных базисах и выполнять минимизацию логических выражений.

Возможности

- ввод логических функций через графический интерфейс
- работа с переменными X1 ... X9
- поддержка констант 0 и 1
- поддержка логических операций:
  - отрицание
  - конъюнкция
  - дизъюнкция
  - исключающее ИЛИ
  - импликация
  - обратная импликация
  - функция Шеффера
  - функция Вебба
  - эквивалентность
- проверка корректности выражения и вывод сообщений об ошибках
- построение таблицы истинности
- синтез:
  - ДСНФ
  - КСНФ
- минимизация логической функции:
  - методом Квайна–Мак-Класки
  - методом коэффициентов
- отображение функции в различных логических базисах
- сохранение и загрузка функций в формате JSON
- сохранение изображений построенных выражений и таблиц
- просмотр всех логических функций для двух аргументов

Структура проекта

- Models/ — логика представления и обработки логических функций
- Views/ — формы пользовательского интерфейса
- StaticData/ — общие данные приложения, таблицы истинности, данные минимизации
- Resources/ — изображения и графические ресурсы интерфейса


Анализ функции
Пользователь может вручную собрать логическое выражение из переменных, констант, скобок и операций.  
Программа проверяет корректность записи и отображает найденные ошибки.

Таблица истинности
Для функции можно построить таблицу истинности, редактировать её и сохранять в файл.

Синтез функции
На основе таблицы истинности программа строит:

- ДСНФ
- КСНФ

Минимизация
Присутствует минимизация логической функции с использованием:

- метода Квайна–Мак-Класки
- метода коэффициентов

Дополнительно отображаются:
- первичные импликанты
- таблица меток
- таблица коэффициентов
- минимальное покрытие

Работа с базисами
Функцию можно преобразовать и представить в различных логических базисах.

Форматы данных

Приложение поддерживает сохранение и загрузку:

- логических функций в JSON
- таблиц истинности в JSON

Также доступен экспорт изображений.

Запуск проекта
Требования

- Windows
- Visual Studio 2022 или новее
- .NET 8 SDK

Сборка и запуск

1. Откройте файл решения Logic_Master.sln в Visual Studio.
2. Восстановите зависимости проекта.
3. Соберите проект.
4. Запустите приложение.

Проект может использоваться:

- в учебных целях
- для изучения булевой алгебры
- для анализа логических выражений
- для подготовки к лабораторным работам по цифровой логике
- как инструмент для наглядной работы с таблицами истинности и нормальными формами

Автор проекта: Апрель



----EN----
Logic Master is a desktop application written in C# for the analysis, synthesis, and minimization of Boolean functions.

The program allows users to enter logical expressions, build truth tables, obtain SDNF and SCNF, represent functions in different logical bases, and perform minimization of logical expressions.

Features

- input of logical functions through a graphical interface
- support for variables X1 ... X9
- support for constants 0 and 1
- support for logical operations:
  - negation
  - conjunction
  - disjunction
  - exclusive OR
  - implication
  - reverse implication
  - Sheffer stroke
  - Peirce arrow
  - equivalence
- expression validation and error reporting
- truth table generation
- synthesis of:
  - SDNF
  - SCNF
- minimization of Boolean functions:
  - using the Quine–McCluskey method
  - using the coefficient method
- representation of functions in different logical bases
- saving and loading functions in JSON format
- saving images of generated expressions and truth tables
- viewing all Boolean functions for two variables

Project structure

- Models/ — logic representation and processing of Boolean functions
- Views/ — user interface forms
- StaticData/ — shared application data, truth tables, and minimization data
- Resources/ — images and graphical interface resources

Function analysis

The user can manually build a logical expression from variables, constants, brackets, and operations.
The program checks the correctness of the expression and displays any detected errors.

Truth table

A truth table can be generated for a function, edited, and saved to a file.

Function synthesis

Based on the truth table, the program generates:

- SDNF
- SCNF

Minimization

The program supports minimization of Boolean functions using:

- the Quine–McCluskey method
- the coefficient method

Additionally, the following are displayed:
- prime implicants
- coverage table
- coefficient table
- minimal cover

Work with logical bases

A function can be transformed and represented in different logical bases.

Data formats

The application supports saving and loading:

- Boolean functions in JSON
- truth tables in JSON

Image export is also available.

Running the project

Requirements

- Windows
- Visual Studio 2022 or newer
- .NET 8 SDK

Build and run

1. Open the Logic_Master.sln solution file in Visual Studio.
2. Restore the project dependencies.
3. Build the solution.
4. Run the application.

The project can be used:

- for educational purposes
- for studying Boolean algebra
- for analyzing logical expressions
- for preparing digital logic laboratory work
- as a tool for visual work with truth tables and canonical forms

Project author: April


**If you download the project as a ZIP archive on Windows, some files may be blocked by the system.
If build errors related to `.resx` files appear, unblock the ZIP file before extracting it or run PowerShell as follows:

Get-ChildItem -Recurse | Unblock-File**
