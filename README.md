# Vizuelno_ZBORLE
Документација на проектната задача на тема „Зборле“ -Предмет Визуелно програмирање

Играта започнува со одбирање мод од почетната страница. Ако модот е играј има 6 обиди да се погоди точниот збор, а ако не се погоди се бележи крај на играта и се прикажува зборот кој не бил погоден. При избор на играј со тајмер покрај ограничувањето со 6 обиди имаме и временска ограниченост. Модот за генерирање на сопствен збор е предвиден за играње во друштво каде еден играч внесува збор а другите ке го погодуваат. Правилата се едноставни внеси валиден збор со 5 букви во текст полто, притисни на копчето потврди и ке се прикаже резултат: зелено (точна буква на точна позиција), жолто (буквата се содржи во зборот но на друга позиција) и сиво (буквата не се содржи во зборот на ниедна позиција).

 ![image](https://github.com/user-attachments/assets/99640ab4-38b5-4551-8474-4e4de6b6da38)

1.	Опис на проблемот/темата
Овој проект претставува реплика на популарната игра „Wordle“ на македонски јазик. Главната цел е играчот да погоди скриен збор од 5 букви во максимум 6 обиди. Играта има три режима: класичен, со тајмер и рачно генерирање на збор, притоа нема дневен лимит како оргиналната игра и останатите нејзини реплики на интернетот.

2.	Функционалности
- Избор на мод кој ке се игра.
- Внесување на збор со тастатура.
- Проверка на внесениот збор според тајниот збор и проверка на валидност на внесениот збор.
- Означување на букви: зелено (точна буква и позиција), жолто (точна буква,погрешна позиција), сиво (погрешна буква).
- Мод со автоматско генерирање на збор од листа на зборови.
- Мод со тајмер за времетраење на игра.
- Мод за генерирање сопствен збор – за играње во друштво.

3.	Опис на решението

3.1.Структура 
Проектот е изграден како Windows Forms апликација користејќи C# и се состои од следниве компоненти:
- Form1.cs – главната форма која ни овозможува избор на мод во кој ке играме.
- PlayForm.cs –форма за игра во класичен мод.
- PlayTimerMode.cs – форма за игра во тајмер мод.
- PlayOwnWordForm.cs – форма за игра на генериран збор од страна на корисник.
- GenerateOwnWordForm.cs – форма за внес на зборот од страна на корисник кој ќе биде погодуван.
- WordProvider.cs – класа која ги вчитува зборовите од текстуален документ, ни дава збор за да играме и прави проверка дали внесен збор е валиден.

3.2.Чување на податоци
- Зборовите кои впрочем се користат за проверка на точноста при внес на збор и избор на збор во модот со тајмер како и класичниот мод се чуваат во текстуален фајл (zborovi.txt) кој се вчитува во листа при иницијализација.


4.	Заеднички особини на трите модови за играње (обичен, тајмер мод и играње сопствен збор)- Опис на класи и функции
4.1.Променливи:
- targetWord ->збор кој треба да се погоди
- currentAttempt -> тековен обид
- maxAttempts -> максимум обиди
- wordLength -> должина на збор
- letterBoxes -> матрица од лабели за прикажување на букви и бои
- provider -> провајдер за зборови

4.2.Конструктор:
Во него се иницијализира формата, провјдерот на зборови, се доделува вредноста на зборот кој ке се погодува и се подесува големина на формата.

4.3.Методи:
- SetupGrid()-> динамички креира “грид-структура„ во која ке се внесуваат зборовите и визуелно ке се претставуваат резултатите, креира текстбокс за внес на зборот,лабела за пораки, копче  за потврда и копче за насочување кон почетната страна.
- BtnBack_Click() -> не враќа на почетната страна.
- BtnConfirm_Click()-> овој метод ја содржи главната логика на играта, тука се прави проврката дали даден збор внесен од тастатура е валиден, дали тој е точниот зборот кој се погодува и се прави графички приказ на резултатот.

5. Разлики во модовите на игра
Иако логиката за проверка на зборот останува иста кај трите мода, разликите се:
- Класичен мод: Играта користи однапред зададен збор добиен по случаен избор.
- Timer мод: Покрај класичната логика, следи и време на играње од две минути. На крај, резултатите се поврзуваат и со изминатото време (ако не се погоди зборот во даденото време играта завршува).
- Мод со рачно генерирање: Скриениот збор се внесува рачно, место да се добива автоматски од WordProvider.

6. WordProvider.cs
- LoadWords()-> читање на зборовите од текстуален документ и запишување во листа.
- GetRandwomWord()->со употреба на Random счучајно се избира збор од листата.
- IsValidWord()->проверка дали зборот се состои во листата.Листата ги содржи генерирани сите зборови со 5 букви што значи дека ако збор не се наоѓа во листата тој е непостоечки/невалиден збор.Се користи за проверка на исправноста на внесот при играње.

7.Користење генеративна вештачка интелигенција
Наидов на проблем при креирање на играта бидејки во windows forms нема грид-структура. Користејки го chatgpt добив два предлога за надминување на проблемот: користење табела (варијанта која не ми се допаѓаше) и користење лабели (варијанта која ми личеше поблиску до грид-структура како и што ми беше замислата за играта). Потоа следен проблем на кој наидов беше тоа што за да имам 6 реда за обиди по 5 букви од збор ке требаше рачно со drag and drop да ставам и потоа центрирам 30 лабели и затоа искористив prompt во chatgpt: Генерирај ми структура која ке има налик на Wordle играта на NYT во windows forms која треба да замени грид од обликот 6 реда со по 5 колони користејки лабели. Одговорот беше кодот кој може да се најде во решенијата на сите модови за игра. Исто така и ми го генерираше полето за внес и двете копчиња затоа што ми беше проблем рачно да ги центрирам во однос на гридот. За зборовите во zborovi.txt искористив prompt: Генерирај ми листа од сите зборови во македонскиот јазик кои имаат 5 букви. Тоа го направив затоа што ќе беше тешко од речник да ги барам сите зборови со 5 букви и да ги внесувам рачно. Остатокот од кодот и дизајнот е изведен рачно.


